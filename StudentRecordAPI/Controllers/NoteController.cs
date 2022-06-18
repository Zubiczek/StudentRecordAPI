using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRecordAPI.Features.NoteFeatures.Commands;
using StudentRecordAPI.Features.NoteFeatures.Queries;
using StudentRecordAPI.Models.AddDTO;
using System;
using System.Net.Mime;
using System.Threading.Tasks;

namespace StudentRecordAPI.Controllers
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("api/[controller]")]
    public class NoteController : ControllerBase
    {
        private readonly ISender _mediator;
        public NoteController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException();
        }
        [HttpGet("student")]
        [Authorize(Roles = "Student")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetStudentNotes()
        {
            return Ok(await _mediator.Send(new GetStudentNotesQuery()));
        }
        [HttpPost("add")]
        [Authorize(Roles = "Teacher")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddNote([FromBody]NoteAddDTO newnote)
        {
            await _mediator.Send(new AddNoteCommand(newnote));
            return Created("~/api/Note/add", newnote);
        }
        [HttpDelete("delete/{Note_id}")]
        [Authorize(Roles = "Teacher")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteNote(int Note_id)
        {
            await _mediator.Send(new DeleteNoteCommand(Note_id));
            return Ok();
        }
    }
}
