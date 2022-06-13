using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRecordAPI.Features.ScheduleFeatures.Queries;
using StudentRecordAPI.Models.Others;
using StudentRecordAPI.Services.ExceptionService;
using System;
using System.Net.Mime;
using System.Threading.Tasks;

namespace StudentRecordAPI.Controllers
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Authorize(Roles = "Student")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class ScheduleController : ControllerBase
    {
        private readonly ISender _mediator;
        private readonly IExceptionService _exceptionService;
        public ScheduleController(ISender mediator, IExceptionService exceptionService)
        {
            _exceptionService = exceptionService;
            _mediator = mediator;
        }
        [HttpGet]
        [Route("class/{Class_id}")]
        public async Task<IActionResult> GetStudentsWholeSchedule(uint Class_id)
        {
            try
            {
                return Ok(await _mediator.Send(new GetStudentScheduleQuery(Class_id)));
            }
            catch (HttpResponseException ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                _exceptionService.LogError(new LogInformation()
                {
                    Request = this.Url.Action("GetStudentsWholeSchedule", "Schedule", this.Request.Scheme),
                    ErrorMessage = ex.ToString()
                });
                return StatusCode(500, ex);
            }
        }
        [HttpGet]
        [Route("day/{day}/class/{Class_id}")]
        public async Task<IActionResult> GetClassScheduleByDate(uint Class_id, DayOfWeek day)
        {
            try
            {
                return Ok(await _mediator.Send(new GetDayScheduleQuery(Class_id, day)));
            }
            catch (HttpResponseException ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                _exceptionService.LogError(new LogInformation()
                {
                    Request = this.Url.Action("GetClassScheduleByDate", "Schedule", this.Request.Scheme),
                    ErrorMessage = ex.ToString()
                });
                return StatusCode(500, ex);
            }
        }
        [HttpGet]
        [Route("next/class/{Class_id}")]
        public async Task<IActionResult> GetNextScheduleSubject(uint Class_id)
        {
            try
            {
                return Ok(await _mediator.Send(new GetNextScheduleSubjectQuery(Class_id)));
            }
            catch (HttpResponseException ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                _exceptionService.LogError(new LogInformation()
                {
                    Request = this.Url.Action("GetNextScheduleSubject", "Schedule", this.Request.Scheme),
                    ErrorMessage = ex.ToString()
                });
                return StatusCode(500, ex);
            }
        }
        [HttpGet]
        [Authorize(Roles = "Teacher")]
        [Route("teacher")]
        public async Task<IActionResult> GetTeachersSchedule()
        {
            try
            {
                return Ok(await _mediator.Send(new GetTeacherScheduleQuery()));
            }
            catch (HttpResponseException ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                _exceptionService.LogError(new LogInformation()
                {
                    Request = this.Url.Action("GetTeachersSchedule", "Schedule", this.Request.Scheme),
                    ErrorMessage = ex.ToString()
                });
                return StatusCode(500, ex);
            }
        }
    }
}
