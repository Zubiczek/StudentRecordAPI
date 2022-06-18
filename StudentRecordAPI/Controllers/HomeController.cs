using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRecordAPI.Features.UserFeatures.Commands;
using StudentRecordAPI.Models.AddDTO;
using System;
using System.Net.Mime;
using System.Threading.Tasks;

namespace StudentRecordAPI.Controllers
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ISender _mediator;
        public HomeController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException();
        }
        [HttpPost("login")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> LogIn([FromBody] LoginDTO logindata)
        {
            return Ok(await _mediator.Send(new LogInCommand(logindata)));
        }
        [HttpPost("account/refreshtoken")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RefreshSession([FromBody] string refreshtoken)
        {
            return Ok(await _mediator.Send(new RefreshSessionCommand(refreshtoken)));
        }
        [HttpDelete("account/logout")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> LogOut()
        {
            await _mediator.Send(new LogOutCommand());
            return Ok();
        }
    }
}
