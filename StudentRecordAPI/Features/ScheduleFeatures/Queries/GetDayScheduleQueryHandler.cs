using MediatR;
using StudentRecordAPI.Models.DTO;
using StudentRecordAPI.Queries.ScheduleQueries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StudentRecordAPI.Features.ScheduleFeatures.Queries
{
    public class GetDayScheduleQueryHandler : IRequestHandler<GetDayScheduleQuery, List<ScheduleSubjectDTO>>
    {
        private readonly IScheduleGetQueries _scheduleGetQueries;
        public GetDayScheduleQueryHandler(IScheduleGetQueries scheduleGetQueries)
        {
            _scheduleGetQueries = scheduleGetQueries;
        }
        public async Task<List<ScheduleSubjectDTO>> Handle(GetDayScheduleQuery query, CancellationToken cancellationToken)
        {
            return await _scheduleGetQueries.GetClassScheduleByDate(query.Class_id, query.dayofweek);
        }
    }
}
