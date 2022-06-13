using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRecordAPI.Features.AttendanceFeatures.Commands;
using StudentRecordAPI.Features.AttendanceFeatures.Queries;
using StudentRecordAPI.Models.AddDTO;
using StudentRecordAPI.Models.Others;
using StudentRecordAPI.Queries.AttendanceQueries;
using StudentRecordAPI.Services.ExceptionService;
using System;
using System.Net.Mime;
using System.Threading.Tasks;

namespace StudentRecordAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class AttendanceController : ControllerBase
    {
        private readonly ISender _mediator;
        private readonly IAttendanceGetQueries _attendanceQueries;
        private readonly IExceptionService _exceptionService;
        public AttendanceController(ISender mediator, IExceptionService exceptionService)
        {
            _mediator = mediator;
            _exceptionService = exceptionService;
        }
        [HttpGet]
        [Authorize(Roles = "Student")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("schedule/{Schedule_id}")]
        public async Task<IActionResult> GetAttendanceList(uint Schedule_id)
        {
            try
            {
                return Ok(await _mediator.Send(new GetAttendanceQuery(Schedule_id)));
            }
            catch (HttpResponseException ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                _exceptionService.LogError(new LogInformation()
                {
                    Request = this.Url.Action("GetAttendanceList", "Attendance", this.Request.Scheme),
                    ErrorMessage = ex.ToString()
                });
                return StatusCode(500, ex);
            }
        }
        [HttpGet]
        [Authorize(Roles = "Student")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("avg/schedule/{Schedule_id}")]
        public async Task<IActionResult> GetAVGAttendance(uint Schedule_id)
        {
            try
            {
                return Ok(await _mediator.Send(new GetAVGAttendanceQuery(Schedule_id)));
            }
            catch (HttpResponseException ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                _exceptionService.LogError(new LogInformation()
                {
                    Request = this.Url.Action("GetAVGAttendance", "Attendance", this.Request.Scheme),
                    ErrorMessage = ex.ToString()
                });
                return StatusCode(500, ex);
            }
        }
        [HttpPost]
        [Authorize(Roles = "Teacher")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("add")]
        public async Task<IActionResult> AddAttendance([FromBody]AttendanceAddDTO attendance)
        {
            try
            {
                await _mediator.Send(new AddAttendanceCommand(attendance));
                return Created("~/api/Attendance/add", attendance);
            }
            catch (HttpResponseException ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                _exceptionService.LogError(new LogInformation()
                {
                    Request = this.Url.Action("AddAttendance", "Attendance", this.Request.Scheme),
                    ErrorMessage = ex.ToString()
                });
                return StatusCode(500, ex);
            }
        }
    }
}
