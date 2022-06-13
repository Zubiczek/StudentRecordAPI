using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRecordAPI.Features.UserFeatures.Commands;
using StudentRecordAPI.Models.AddDTO;
using StudentRecordAPI.Models.Others;
using StudentRecordAPI.Services.ExceptionService;
using System;
using System.Net.Mime;
using System.Threading.Tasks;

namespace StudentRecordAPI.Controllers
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly ISender _mediator;
        private readonly IExceptionService _exceptionService;
        public AdminController(ISender mediator, IExceptionService exceptionService)
        {
            _mediator = mediator;
            _exceptionService = exceptionService;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("createuser")]
        public async Task<IActionResult> SignUpNewUser(NewUserDTO newuser, string role)
        {
            try
            {
                string createduserid = await _mediator.Send(new AddNewUserCommand(newuser, role));
                return CreatedAtAction("SuccessRegistration", new { controller = "User", id = createduserid }, newuser);
            }
            catch(HttpResponseException ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch(Exception ex)
            {
                _exceptionService.LogError(new LogInformation()
                {
                    Request = this.Url.Action("SignUpNewUser", "Admin", new { newuser = newuser, role = role }, this.Request.Scheme),
                    ErrorMessage = ex.ToString()
                });
                return StatusCode(500, ex);
            }
        }
    }
}
