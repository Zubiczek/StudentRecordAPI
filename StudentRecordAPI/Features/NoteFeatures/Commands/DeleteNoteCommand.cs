using MediatR;

namespace StudentRecordAPI.Features.NoteFeatures.Commands
{
    public class DeleteNoteCommand : IRequest
    {
        public uint Note_id { get; set; }
        public DeleteNoteCommand(uint Note_id)
        {
            this.Note_id = Note_id;
        }
    }
}
