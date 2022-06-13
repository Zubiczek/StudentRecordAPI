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
    public class GetSubjectGradesQueryHandler : IRequestHandler<GetSubjectGradesQuery, List<GradeInfoDTO>>
    {
        private readonly IGradeGetQueries _gradeGetQueries;
        public GetSubjectGradesQueryHandler(IGradeGetQueries gradeGetQueries)
        {
            _gradeGetQueries = gradeGetQueries;
        }
        public async Task<List<GradeInfoDTO>> Handle(GetSubjectGradesQuery query, CancellationToken cancellationToken)
        {
            return await _gradeGetQueries.GetGradesFromSubject(query.Subject_id);
        }
    }
}
