using MediatR;
using StudentRecordAPI.Queries.GradeQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StudentRecordAPI.Features.GradeFeatures.Queries
{
    public class GetGradesAVGQueryHandler : IRequestHandler<GetGradesAVGQuery, float>
    {
        private readonly IGradeGetQueries _gradeGetQueries;
        public GetGradesAVGQueryHandler(IGradeGetQueries gradeGetQueries)
        {
            _gradeGetQueries = gradeGetQueries;
        }
        public async Task<float> Handle(GetGradesAVGQuery query, CancellationToken cancellationToken)
        {
            return await _gradeGetQueries.GetAverageGradeFromSubject(query.Subject_id);
        }
    }
}
