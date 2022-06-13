using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRecordAPI.Features.ClassFeatures.Commands;
using StudentRecordAPI.Features.ClassFeatures.Queries;
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
    public class ClassController : ControllerBase
    {
        private readonly ISender _mediator;
        private readonly IExceptionService _exceptionService;
        public ClassController(ISender mediator, IExceptionService exceptionService)
        {
            _mediator = mediator;
            _exceptionService = exceptionService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Teacher")]
        [Route("students/{Class_id}")]
        public async Task<IActionResult> GetListOfStudents(uint Class_id)
        {
            try
            {
                return Ok(await _mediator.Send(new GetClassStudentsQuery(Class_id)));
            }
            catch (HttpResponseException ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                _exceptionService.LogError(new LogInformation()
                {
                    Request = this.Url.Action("GetListOfStudents", "Class", this.Request.Scheme),
                    ErrorMessage = ex.ToString()
                });
                return StatusCode(500, ex);
            }
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Admin")]
        [Route("assign/student/{Student_id}/{Class_id}")]
        public async Task<IActionResult> AddNewStudentToClass(string Student_id, uint Class_id)
        {
            try
            {
                await _mediator.Send(new AddStudentToClassCommand(Student_id, Class_id));
                return Ok();
            }
            catch (HttpResponseException ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                _exceptionService.LogError(new LogInformation()
                {
                    Request = this.Url.Action("AddNewStudentToClass", "Class", this.Request.Scheme),
                    ErrorMessage = ex.ToString()
                });
                return StatusCode(500, ex);
            }
        }
    }
}
