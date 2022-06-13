using MediatR;
using StudentRecordAPI.Queries.NoteQueries;
using System.Threading;
using System.Threading.Tasks;

namespace StudentRecordAPI.Features.NoteFeatures.Commands
{
    public class AddNoteCommandHandler : IRequestHandler<AddNoteCommand, Unit>
    {
        private readonly INotePostQueries _notePostQueries;
        public AddNoteCommandHandler(INotePostQueries notePostQueries)
        {
            _notePostQueries = notePostQueries;
        }
        public async Task<Unit> Handle(AddNoteCommand query, CancellationToken cancellationToken)
        {
            await _notePostQueries.AddNote(query.note);
            return Unit.Value;
        }
    }
}
