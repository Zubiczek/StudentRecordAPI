using Microsoft.AspNetCore.Identity;
using StudentRecordAPI.Database.Entities;
using StudentRecordAPI.Models.AddDTO;
using StudentRecordAPI.Models.Others;
using StudentRecordAPI.Services.LoggedInUserService;
using StudentRecordAPI.Services.TokenService;
using StudentRecordAPI.Services.ValidationService;
using System;
using System.Threading.Tasks;

namespace StudentRecordAPI.Services.LoginService
{
    public class LoginService : ILoginService
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly ILoggedInUserService _userService;
        private readonly IValidationService _validationService;
        public LoginService(UserManager<UserEntity> userManager, ITokenService tokenService, SignInManager<UserEntity> signInManager,
            ILoggedInUserService userService, IValidationService validationService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
            _userService = userService;
            _validationService = validationService;
        }
        public async Task<TokenOutput> LogIn(LoginDTO logindata)
        {
            var validationmodelresult = _validationService.Validate(logindata);
            if (!validationmodelresult.Item1) throw new HttpResponseException(validationmodelresult.Item2, 400);
            var user = await _userManager.FindByEmailAsync(logindata.Email);
            if (user == null) throw new HttpResponseException("Niepoprawny login lub hasło!", 401);
            var ispasswordcorrect = await _signInManager.CheckPasswordSignInAsync(user, logindata.Password, false);
            if(!ispasswordcorrect.Succeeded) throw new HttpResponseException("Niepoprawny login lub hasło!", 401);
            var accessToken = _tokenService.CreateAccessToken(user);
            return new TokenOutput()
            {
                AccessToken = accessToken.Item1,
                Expires = accessToken.Item2,
                RefreshToken = await _tokenService.CreateRefreshToken(user.Id),
                Email = user.Email,
                Id = user.Id
            };
        }
        public Task<TokenOutput> RefreshSession()
        {
            throw new NotImplementedException();
        }
        public async Task LogOut()
        {
            await _tokenService.RemoveRefreshToken(_userService.GetUserId());
            await _userService.LogOut();
        }
    }
}
