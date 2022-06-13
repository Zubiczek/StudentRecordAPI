using MediatR;
using StudentRecordAPI.Models.DTO;
using StudentRecordAPI.Queries.ScheduleQueries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StudentRecordAPI.Features.ScheduleFeatures.Queries
{
    public class GetStudentScheduleQueryHandler : IRequestHandler<GetStudentScheduleQuery, List<List<ScheduleSubjectDTO>>>
    {
        private readonly IScheduleGetQueries _scheduleGetQueries;
        public GetStudentScheduleQueryHandler(IScheduleGetQueries scheduleGetQueries)
        {
            _scheduleGetQueries = scheduleGetQueries;
        }
        public async Task<List<List<ScheduleSubjectDTO>>> Handle(GetStudentScheduleQuery query, CancellationToken cancellationToken)
        {
            return await _scheduleGetQueries.GetWholeStudentSchedule(query.Class_id);
        }
    }
}
