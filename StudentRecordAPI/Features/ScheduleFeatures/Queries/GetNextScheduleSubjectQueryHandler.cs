using MediatR;
using StudentRecordAPI.Models.DTO;
using StudentRecordAPI.Queries.ScheduleQueries;
using System.Threading;
using System.Threading.Tasks;

namespace StudentRecordAPI.Features.ScheduleFeatures.Queries
{
    public class GetNextScheduleSubjectQueryHandler : IRequestHandler<GetNextScheduleSubjectQuery, ScheduleSubjectDTO>
    {
        private readonly IScheduleGetQueries _scheduleGetQueries;
        public GetNextScheduleSubjectQueryHandler(IScheduleGetQueries scheduleGetQueries)
        {
            _scheduleGetQueries = scheduleGetQueries;
        }
        public async Task<ScheduleSubjectDTO> Handle(GetNextScheduleSubjectQuery query, CancellationToken cancellationToken)
        {
            return await _scheduleGetQueries.GetNextScheduleSubject(query.Class_id);
        }
    }
}
