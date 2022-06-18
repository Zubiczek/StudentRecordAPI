using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRecordAPI.Features.GradeFeatures.Commands;
using StudentRecordAPI.Features.GradeFeatures.Queries;
using StudentRecordAPI.Models.AddDTO;
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
        public GradeController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException();
        }
        [HttpGet("all")]
        [Authorize(Roles = "Student")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllGrades()
        {
            return Ok(await _mediator.Send(new GetAllGradesQuery()));
        }
        [HttpGet("subject/{Subject_id}")]
        [Authorize(Roles = "Student")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetGradesFromSubject(int Subject_id)
        {
            return Ok(await _mediator.Send(new GetSubjectGradesQuery(Subject_id)));
        }
        [HttpGet("subject/{Subject_id}/avg")]
        [Authorize(Roles = "Student")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetGradesAVGFromSubject(int Subject_id)
        {
            return Ok(await _mediator.Send(new GetGradesAVGQuery(Subject_id)));
        }
        [HttpGet("{Grade_id}")]
        [Authorize(Roles = "Student,Teacher")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetMoreInfoAboutGrade(int Grade_id)
        {
            return Ok(await _mediator.Send(new GetMoreGradeInfoQuery(Grade_id)));
        }
        [HttpGet("student/{Student_id}/subject/{Subject_id}")]
        [Authorize(Roles = "Teacher")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetStudentGradesFromSubject(GradeSubjectDTO ids)
        {
            return Ok(await _mediator.Send(new GetStudentGradesQuery(ids)));
        }
        [HttpPost("add")]
        [Authorize(Roles = "Teacher")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddNewGrade([FromBody] GradeAddDTO Grade)
        {
            await _mediator.Send(new AddGradeCommand(Grade));
            return CreatedAtAction("AddNewGrade", new { controller = "Grade"}, Grade);
        }
        [HttpDelete("delete/{Grade_id}")]
        [Authorize(Roles = "Teacher")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteGrade(int Grade_id)
        {
            await _mediator.Send(new DeleteGradeCommand(Grade_id));
            return Ok();
        }
        [HttpPut("update/{Grade_id}")]
        [Authorize(Roles = "Teacher")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateGrade(int Grade_id, float Grade)
        {
            await _mediator.Send(new UpdateGradeCommand(Grade_id, Grade));
            return Ok();
        }
    }
}
