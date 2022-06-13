using AutoMapper;
using Microsoft.AspNetCore.Identity;
using StudentRecordAPI.Database.Entities;
using StudentRecordAPI.Models.AddDTO;
using StudentRecordAPI.Models.Others;
using StudentRecordAPI.Services.EmailService;
using StudentRecordAPI.Services.PasswordService;
using StudentRecordAPI.Services.ValidationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRecordAPI.Services.RegistrationService
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<UserEntity> _userManager;
        private readonly IRandomPassword _randomPassword;
        private readonly IValidationService _validationService;
        private readonly IEmailService _emailService;
        public RegistrationService(IMapper mapper, UserManager<UserEntity> userManager, IRandomPassword randomPassword,
            IValidationService validationService, IEnumerable<IEmailService> emailServices)
        {
            _mapper = mapper;
            _userManager = userManager;
            _randomPassword = randomPassword;
            _validationService = validationService;
            _emailService = emailServices.First(x => x.GetType() == typeof(RegistrationEmailService));
        }
        public async Task<string> CreateNewUser(NewUserDTO newuser, string role)
        {
            var validationresult = _validationService.Validate(newuser);
            if (!validationresult.Item1) throw new HttpResponseException(validationresult.Item2, 400);
            var existinguser = await _userManager.FindByEmailAsync(newuser.Email);
            if (existinguser != null) throw new HttpResponseException("Użytkownik o podanym e-mailu istnieje!", 409);
            var user = _mapper.Map<UserEntity>(newuser);
            var passwordHash = new PasswordHasher<UserEntity>();
            string password = _randomPassword.Generate();
            var hashed = passwordHash.HashPassword(user, password);
            user.PasswordHash = hashed;
            user.EmailConfirmed = true;
            user.NormalizedEmail = user.Email.ToUpper();
            user.NormalizedUserName = user.UserName.ToUpper();
            user.SecurityStamp = Guid.NewGuid().ToString();
            var createuserresult = await _userManager.CreateAsync(user);
            if (!createuserresult.Succeeded) throw new HttpResponseException();
            var addroleresult = await _userManager.AddToRoleAsync(user, role);
            if (!addroleresult.Succeeded) throw new HttpResponseException("Invalid role!", 500);
            await _emailService.SendEmail(user.Email, password);
            return user.Id;
        }
    }
}
