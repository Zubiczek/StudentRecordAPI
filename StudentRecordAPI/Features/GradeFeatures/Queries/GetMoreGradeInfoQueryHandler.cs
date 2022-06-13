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
    public class GetMoreGradeInfoQueryHandler : IRequestHandler<GetMoreGradeInfoQuery, GradeMoreInfoDTO>
    {
        private readonly IGradeGetQueries _gradeGetQueries;
        public GetMoreGradeInfoQueryHandler(IGradeGetQueries gradeGetQueries)
        {
            _gradeGetQueries = gradeGetQueries;
        }
        public async Task<GradeMoreInfoDTO> Handle(GetMoreGradeInfoQuery query, CancellationToken cancellationToken)
        {
            return await _gradeGetQueries.GetInfoAboutGrade(query.Grade_id);
        }
    }
}
