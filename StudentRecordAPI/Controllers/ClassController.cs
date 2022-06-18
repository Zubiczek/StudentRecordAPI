using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRecordAPI.Features.ClassFeatures.Commands;
using StudentRecordAPI.Features.ClassFeatures.Queries;
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
        public ClassController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException();
        }
        [HttpGet("{Class_id}/students")]
        [Authorize(Roles = "Teacher")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetListOfStudents(int Class_id)
        {
            return Ok(await _mediator.Send(new GetClassStudentsQuery(Class_id)));
        }
        [HttpPut("{Class_id}/addstudent/{Student_id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddNewStudentToClass(string Student_id, int Class_id)
        {
            await _mediator.Send(new AddStudentToClassCommand(Student_id, Class_id));
            return Ok();
        }
    }
}
