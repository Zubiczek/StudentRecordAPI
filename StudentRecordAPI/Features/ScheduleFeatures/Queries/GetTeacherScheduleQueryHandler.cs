using MediatR;
using StudentRecordAPI.Models.DTO;
using StudentRecordAPI.Queries.ScheduleQueries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StudentRecordAPI.Features.ScheduleFeatures.Queries
{
    public class GetTeacherScheduleQueryHandler : IRequestHandler<GetTeacherScheduleQuery, List<TeacherScheduleDTO>>
    {
        private readonly IScheduleGetQueries _scheduleGetQueries;
        public GetTeacherScheduleQueryHandler(IScheduleGetQueries scheduleGetQueries)
        {
            _scheduleGetQueries = scheduleGetQueries;
        }
        public async Task<List<TeacherScheduleDTO>> Handle(GetTeacherScheduleQuery query, CancellationToken cancellationToken)
        {
            return await _scheduleGetQueries.GetTodayTeacherSchedule();
        }
    }
}
