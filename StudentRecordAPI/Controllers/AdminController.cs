using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRecordAPI.Features.ClassFeatures.Commands;
using StudentRecordAPI.Features.ScheduleFeatures.Commands;
using StudentRecordAPI.Features.UserFeatures.Commands;
using StudentRecordAPI.Models.AddDTO;
using StudentRecordAPI.Models.Others;
using StudentRecordAPI.Services.ExceptionService;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;

namespace StudentRecordAPI.Controllers
{
    [ApiController]
    [Authorize(Roles = "Admin")]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly ISender _mediator;
        public AdminController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException();
        }
        [HttpPost("user/create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SignUpNewUser(NewUserDTO newuser, string role)
        {
            string createduserid = await _mediator.Send(new AddNewUserCommand(newuser, role));
            return CreatedAtAction("SuccessRegistration", new { controller = "User", id = createduserid }, newuser);
        }
        [HttpPost("class/addstudent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddNewStudentToClass(int Class_id, string Student_id)
        {
            await _mediator.Send(new AddStudentToClassCommand(Student_id, Class_id));
            return Ok();
        }
        [HttpPost("schedule/update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateSchedule([FromBody] List<NewScheduleDTO> schedule)
        {
            await _mediator.Send(new UpdateWholeScheduleCommand(schedule));
            return Ok();
        }
    }
}
