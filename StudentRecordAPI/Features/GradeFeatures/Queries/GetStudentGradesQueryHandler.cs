using MediatR;
using StudentRecordAPI.Models.DTO;
using StudentRecordAPI.Queries.GradeQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StudentRecordAPI.Features.GradeFeatures.Queries
{
    public class GetStudentGradesQueryHandler : IRequestHandler<GetStudentGradesQuery, List<GradeInfoDTO>>
    {
        private readonly IGradeGetQueries _gradeGetQueries;
        public GetStudentGradesQueryHandler(IGradeGetQueries gradeGetQueries)
        {
            _gradeGetQueries = gradeGetQueries;
        }
        public async Task<List<GradeInfoDTO>> Handle(GetStudentGradesQuery query, CancellationToken cancellationToken)
        {
            return await _gradeGetQueries.GetStudentGradesFromSubject(query.gradeandsubjectids);
        }
    }
}
