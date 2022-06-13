using AutoMapper;
using Microsoft.AspNetCore.Identity;
using StudentRecordAPI.Database.Entities;
using StudentRecordAPI.Models.AddDTO;
using StudentRecordAPI.Models.Others;
using StudentRecordAPI.Services.PasswordService;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace StudentRecordAPI.Queries.UserQueries
{
    public class UserQueries : IRegisterQueries
    {
        private readonly IMapper _mapper;
        private readonly UserManager<UserEntity> _userManager;
        private readonly IRandomPassword _randomPassword;
        public UserQueries(IMapper mapper, UserManager<UserEntity> userManager, IRandomPassword randomPassword)
        {
            _mapper = mapper;
            _userManager = userManager;
            _randomPassword = randomPassword;
        }
        public async Task CreateNewUser(NewUserDTO newuser, string role)
        {
            var existinguser = await _userManager.FindByEmailAsync(newuser.Email);
            if (existinguser != null) throw new HttpResponseException("Użytkownik o podanym emailu istnieje!", 409);
            var user = _mapper.Map<UserEntity>(newuser);
            var results = new List<ValidationResult>();
            var context = new ValidationContext(user, null, null);
            if (!Validator.TryValidateObject(user, context, results)) throw new HttpResponseException(results[0].ErrorMessage, 400);
            var passwordHash = new PasswordHasher<UserEntity>();
            var hashed = passwordHash.HashPassword(user, _randomPassword.Generate());
            user.Id = Guid.NewGuid().ToString();
            user.PasswordHash = hashed;
            user.EmailConfirmed = true;
            user.NormalizedEmail = user.Email.ToUpper();
            user.NormalizedUserName = user.UserName.ToUpper();
            user.SecurityStamp = Guid.NewGuid().ToString();
            var createuserresult = await _userManager.CreateAsync(user);
            if (!createuserresult.Succeeded) throw new HttpResponseException();
            await _userManager.AddToRoleAsync(user, role);
        }
    }
}
