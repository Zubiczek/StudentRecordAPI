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
    public class GetAllGradesQueryHandler : IRequestHandler<GetAllGradesQuery, List<List<GradeInfoSubjectDTO>>>
    {
        private readonly IGradeGetQueries _gradeGetQueries;
        public GetAllGradesQueryHandler(IGradeGetQueries gradeGetQueries)
        {
            _gradeGetQueries = gradeGetQueries;
        }
        public async Task<List<List<GradeInfoSubjectDTO>>> Handle(GetAllGradesQuery query, CancellationToken cancellationToken)
        {
            return await _gradeGetQueries.GetAllGrades();
        }
    }
}
