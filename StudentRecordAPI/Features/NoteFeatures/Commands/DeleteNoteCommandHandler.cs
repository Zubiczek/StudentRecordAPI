using MediatR;
using StudentRecordAPI.Queries.NoteQueries;
using System.Threading;
using System.Threading.Tasks;

namespace StudentRecordAPI.Features.NoteFeatures.Commands
{
    public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand, Unit>
    {
        private readonly INotePostQueries _notePostQueries;
        public DeleteNoteCommandHandler(INotePostQueries notePostQueries)
        {
            _notePostQueries = notePostQueries;
        }
        public async Task<Unit> Handle(DeleteNoteCommand query, CancellationToken cancellationToken)
        {
            await _notePostQueries.DeleteNote(query.Note_id);
            return Unit.Value;
        }
    }
}
