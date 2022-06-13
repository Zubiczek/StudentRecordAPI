using MediatR;
using StudentRecordAPI.Models.AddDTO;

namespace StudentRecordAPI.Features.NoteFeatures.Commands
{
    public class AddNoteCommand : IRequest
    {
        public NoteAddDTO note { get; set; }
        public AddNoteCommand(NoteAddDTO note)
        {
            this.note = note;
        }
    }
}
