using MediatR;
using StudentRecordAPI.Models.DTO;
using StudentRecordAPI.Queries.AttendanceQueries;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StudentRecordAPI.Features.AttendanceFeatures.Queries
{
    public class GetAttendanceQueryHandler : IRequestHandler<GetAttendanceQuery, List<AttendanceDTO>>
    {
        private readonly IAttendanceGetQueries _attendanceGetQueries;
        public GetAttendanceQueryHandler(IAttendanceGetQueries attendanceGetQueries)
        {
            _attendanceGetQueries = attendanceGetQueries ?? throw new ArgumentNullException();
        }
        public async Task<List<AttendanceDTO>> Handle(GetAttendanceQuery query, CancellationToken cancellationToken)
        {
            return await _attendanceGetQueries.GetAttendanceListFromSubject(query.Schedule_id);
        }
    }
}
