using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRecordAPI.Features.ScheduleFeatures.Queries;
using System;
using System.Net.Mime;
using System.Threading.Tasks;

namespace StudentRecordAPI.Controllers
{
    [ApiController]
    [Authorize(Roles = "Student")]
    [Produces(MediaTypeNames.Application.Json)]
    public class ScheduleController : ControllerBase
    {
        private readonly ISender _mediator;
        public ScheduleController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException();
        }
        [HttpGet("class/{Class_id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetStudentsWholeSchedule(int Class_id)
        {
            return Ok(await _mediator.Send(new GetStudentScheduleQuery(Class_id)));
        }
        [HttpGet("day/{day}/class/{Class_id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetClassScheduleByDate(int Class_id, DayOfWeek day)
        {
            return Ok(await _mediator.Send(new GetDayScheduleQuery(Class_id, day)));
        }
        [HttpGet("next/class/{Class_id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetNextScheduleSubject(int Class_id)
        {
            return Ok(await _mediator.Send(new GetNextScheduleSubjectQuery(Class_id)));
        }
        [HttpGet("teacher")]
        [Authorize(Roles = "Teacher")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTeachersSchedule()
        {
            return Ok(await _mediator.Send(new GetTeacherScheduleQuery()));
        }
    }
}
