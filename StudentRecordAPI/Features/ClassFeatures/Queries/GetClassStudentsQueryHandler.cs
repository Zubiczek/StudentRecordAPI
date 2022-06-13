using MediatR;
using StudentRecordAPI.Models.DTO;
using StudentRecordAPI.Queries.ClassQueries;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StudentRecordAPI.Features.ClassFeatures.Queries
{
    public class GetClassStudentsQueryHandler : IRequestHandler<GetClassStudentsQuery, List<StudentsDTO>>
    {
        private readonly IClassGetQueries _classGetQueries;
        public GetClassStudentsQueryHandler(IClassGetQueries classGetQueries)
        {
            _classGetQueries = classGetQueries ?? throw new ArgumentNullException();
        }
        public async Task<List<StudentsDTO>> Handle(GetClassStudentsQuery query, CancellationToken cancellationToken)
        {
            return await _classGetQueries.GetListOfStudents(query.Class_id);
        }
    }
}
