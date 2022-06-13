using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRecordAPI.Features.NoteFeatures.Commands;
using StudentRecordAPI.Features.NoteFeatures.Queries;
using StudentRecordAPI.Models.AddDTO;
using StudentRecordAPI.Models.Others;
using StudentRecordAPI.Services.ExceptionService;
using System;
using System.Net.Mime;
using System.Threading.Tasks;

namespace StudentRecordAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class NoteController : ControllerBase
    {
        private readonly ISender _mediator;
        private readonly IExceptionService _exceptionService;
        public NoteController(ISender mediator, IExceptionService exceptionService)
        {
            _mediator = mediator;
            _exceptionService = exceptionService;
        }
        [HttpGet]
        [Authorize(Roles = "Student")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("student")]
        public async Task<IActionResult> GetStudentNotes()
        {
            try
            {
                return Ok(await _mediator.Send(new GetStudentNotesQuery()));
            }
            catch (HttpResponseException ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                _exceptionService.LogError(new LogInformation()
                {
                    Request = this.Url.Action("GetStudentNotes", "Note", this.Request.Scheme),
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
        public async Task<IActionResult> AddNote([FromBody]NoteAddDTO newnote)
        {
            try
            {
                await _mediator.Send(new AddNoteCommand(newnote));
                return Created("~/api/Note/add", newnote);
            }
            catch (HttpResponseException ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                _exceptionService.LogError(new LogInformation()
                {
                    Request = this.Url.Action("AddNote", "Note", this.Request.Scheme),
                    ErrorMessage = ex.ToString()
                });
                return StatusCode(500, ex);
            }
        }
        [HttpDelete]
        [Authorize(Roles = "Teacher")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("delete/{Note_id}")]
        public async Task<IActionResult> DeleteNote(uint Note_id)
        {
            try
            {
                await _mediator.Send(new DeleteNoteCommand(Note_id));
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
                    Request = this.Url.Action("DeleteNote", "Note", this.Request.Scheme),
                    ErrorMessage = ex.ToString()
                });
                return StatusCode(500, ex);
            }
        }
    }
}
