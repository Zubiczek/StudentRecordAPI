using MediatR;

namespace StudentRecordAPI.Features.NoteFeatures.Commands
{
    public class DeleteNoteCommand : IRequest
    {
        public int Note_id { get; set; }
        public DeleteNoteCommand(int Note_id)
        {
            this.Note_id = Note_id;
        }
    }
}
