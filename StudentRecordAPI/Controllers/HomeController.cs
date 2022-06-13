using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRecordAPI.Models.AddDTO;
using StudentRecordAPI.Models.Others;
using StudentRecordAPI.Services.ExceptionService;
using StudentRecordAPI.Services.LoginService;
using StudentRecordAPI.Services.ValidationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace StudentRecordAPI.Controllers
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IExceptionService _exceptionService;
        public HomeController(ILoginService loginService, IExceptionService exceptionService)
        {
            _loginService = loginService;
            _exceptionService = exceptionService;

        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        [Route("Index/Login")]
        public async Task<IActionResult> LogIn([FromBody] LoginDTO logindata)
        {
            try
            {
                var loggedInUser = await _loginService.LogIn(logindata);
                return Ok(loggedInUser);
            }
            catch(HttpResponseException ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch(Exception ex)
            {
                _exceptionService.LogError(new LogInformation()
                {
                    Request = this.Url.Action("LogIn", "Home", new { logindata = logindata }, this.Request.Scheme),
                    ErrorMessage = ex.ToString()
                });
                return StatusCode(500, ex);
            }
        }
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        [Route("Account/LogOut")]
        public async Task<IActionResult> LogOut()
        {
            try
            {
                await _loginService.LogOut();
                return Ok();
            }
            catch(HttpResponseException ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch(Exception ex)
            {
                _exceptionService.LogError(new LogInformation()
                {
                    Request = this.Url.Action("LogOut", "Home", this.Request.Scheme),
                    ErrorMessage = ex.ToString()
                });
                return StatusCode(500, ex);
            }
        }
    }
}
