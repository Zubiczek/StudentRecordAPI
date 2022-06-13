using MediatR;
using StudentRecordAPI.Models.DTO;
using StudentRecordAPI.Queries.NoteQueries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StudentRecordAPI.Features.NoteFeatures.Queries
{
    public class GetStudentNotesQueryHandler : IRequestHandler<GetStudentNotesQuery, List<NoteDTO>>
    {
        private readonly INoteGetQueries _noteGetQueries;
        public GetStudentNotesQueryHandler(INoteGetQueries notePostQueries)
        {
            _noteGetQueries = notePostQueries;
        }
        public async Task<List<NoteDTO>> Handle(GetStudentNotesQuery query, CancellationToken cancellationToken)
        {
            return await _noteGetQueries.GetStudentNotes();
        }
    }
}
