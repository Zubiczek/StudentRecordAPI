using MediatR;
using StudentRecordAPI.Queries.AttendanceQueries;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudentRecordAPI.Features.AttendanceFeatures.Queries
{
    public class GetAVGAttendanceQueryHandler : IRequestHandler<GetAVGAttendanceQuery, float>
    {
        private readonly IAttendanceGetQueries _attendanceGetQueries;
        public GetAVGAttendanceQueryHandler(IAttendanceGetQueries attendanceGetQueries)
        {
            _attendanceGetQueries = attendanceGetQueries ?? throw new ArgumentNullException();
        }
        public async Task<float> Handle(GetAVGAttendanceQuery query, CancellationToken cancellationToken)
        {
            return await _attendanceGetQueries.GetAVGAttendance(query.Schedule_id);
        }
    }
}
