using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRecordAPI.Features.AttendanceFeatures.Commands;
using StudentRecordAPI.Features.AttendanceFeatures.Queries;
using StudentRecordAPI.Models.AddDTO;
using System;
using System.Net.Mime;
using System.Threading.Tasks;

namespace StudentRecordAPI.Controllers
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("api/[controller]")]
    public class AttendanceController : ControllerBase
    {
        private readonly ISender _mediator;
        public AttendanceController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException();
        }
        [HttpGet("schedule/{Schedule_id}")]
        [Authorize(Roles = "Student")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAttendanceList(int Schedule_id)
        {
            return Ok(await _mediator.Send(new GetAttendanceQuery(Schedule_id)));
        }
        [HttpGet("schedule/{Schedule}/avg")]
        [Authorize(Roles = "Student")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAVGAttendance(int Schedule_id)
        {
            return Ok(await _mediator.Send(new GetAVGAttendanceQuery(Schedule_id)));
        }
        [HttpPost("add")]
        [Authorize(Roles = "Teacher")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddAttendance([FromBody]AttendanceAddDTO attendance)
        {
            await _mediator.Send(new AddAttendanceCommand(attendance));
            return Created("~/api/Attendance/add", attendance);
        }
    }
}
