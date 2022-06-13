using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRecordAPI.Features.GradeFeatures.Commands;
using StudentRecordAPI.Features.GradeFeatures.Queries;
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
    public class GradeController : ControllerBase
    {
        private readonly ISender _mediator;
        private readonly IExceptionService _exceptionService;
        public GradeController(ISender mediator, IExceptionService exceptionService)
        {
            _mediator = mediator;
            _exceptionService = exceptionService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Student")]
        [Route("grades")]
        public async Task<IActionResult> GetAllGrades()
        {
            try
            {
                return Ok(await _mediator.Send(new GetAllGradesQuery()));
            }
            catch(HttpResponseException ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch(Exception ex)
            {
                _exceptionService.LogError(new LogInformation()
                {
                    Request = this.Url.Action("GetAllGrades", "Grade", this.Request.Scheme),
                    ErrorMessage = ex.ToString()
                });
                return StatusCode(500, ex);
            }
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Student")]
        [Route("subject/{Subject_id}")]
        public async Task<IActionResult> GetGradesFromSubject(uint Subject_id)
        {
            try
            {
                return Ok(await _mediator.Send(new GetSubjectGradesQuery(Subject_id)));
            }
            catch (HttpResponseException ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                _exceptionService.LogError(new LogInformation()
                {
                    Request = this.Url.Action("GetGradesFromSubject", "Grade", this.Request.Scheme),
                    ErrorMessage = ex.ToString()
                });
                return StatusCode(500, ex);
            }
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Student")]
        [Route("average/{Subject_id}")]
        public async Task<IActionResult> GetGradesAVGFromSubject(uint Subject_id)
        {
            try
            {
                return Ok(await _mediator.Send(new GetGradesAVGQuery(Subject_id)));
            }
            catch (HttpResponseException ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                _exceptionService.LogError(new LogInformation()
                {
                    Request = this.Url.Action("GetGradesAVGFromSubject", "Grade", this.Request.Scheme),
                    ErrorMessage = ex.ToString()
                });
                return StatusCode(500, ex);
            }
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Student,Teacher")]
        [Route("grade/{Grade_id}")]
        public async Task<IActionResult> GetMoreInfoAboutGrade(uint Grade_id)
        {
            try
            {
                return Ok(await _mediator.Send(new GetMoreGradeInfoQuery(Grade_id)));
            }
            catch (HttpResponseException ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                _exceptionService.LogError(new LogInformation()
                {
                    Request = this.Url.Action("GetMoreInfoAboutGrade", "Grade", this.Request.Scheme),
                    ErrorMessage = ex.ToString()
                });
                return StatusCode(500, ex);
            }
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Teacher")]
        [Route("student/{Student_id}/{Subject_id}")]
        public async Task<IActionResult> GetStudentGradesFromSubject(GradeSubjectDTO ids)
        {
            try
            {
                return Ok(await _mediator.Send(new GetStudentGradesQuery(ids)));
            }
            catch (HttpResponseException ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                _exceptionService.LogError(new LogInformation()
                {
                    Request = this.Url.Action("GetStudentGradesFromSubject", "Grade", this.Request.Scheme),
                    ErrorMessage = ex.ToString()
                });
                return StatusCode(500, ex);
            }
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Teacher")]
        [Route("add")]
        public async Task<IActionResult> AddNewGrade([FromBody] GradeAddDTO Grade)
        {
            try
            {
                await _mediator.Send(new AddGradeCommand(Grade));
                return CreatedAtAction("AddNewGrade", new { controller = "Grade"}, Grade);
            }
            catch (HttpResponseException ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                _exceptionService.LogError(new LogInformation()
                {
                    Request = this.Url.Action("AddNewGrade", "Grade", this.Request.Scheme),
                    ErrorMessage = ex.ToString()
                });
                return StatusCode(500, ex);
            }
        }
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Teacher")]
        [Route("delete/{Grade_id}")]
        public async Task<IActionResult> DeleteGrade(uint Grade_id)
        {
            try
            {
                await _mediator.Send(new DeleteGradeCommand(Grade_id));
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
                    Request = this.Url.Action("DeleteGrade", "Grade", this.Request.Scheme),
                    ErrorMessage = ex.ToString()
                });
                return StatusCode(500, ex);
            }
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Teacher")]
        [Route("update/{Grade_id}/{Grade}")]
        public async Task<IActionResult> UpdateGrade(uint Grade_id, float Grade)
        {
            try
            {
                await _mediator.Send(new UpdateGradeCommand(Grade_id,Grade));
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
                    Request = this.Url.Action("UpdateGrade", "Grade", this.Request.Scheme),
                    ErrorMessage = ex.ToString()
                });
                return StatusCode(500, ex);
            }
        }
    }
}
