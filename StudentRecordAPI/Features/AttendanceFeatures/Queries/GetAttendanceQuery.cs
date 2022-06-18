using MediatR;
using StudentRecordAPI.Models.DTO;
using System.Collections.Generic;

namespace StudentRecordAPI.Features.AttendanceFeatures.Queries
{
    public class GetAttendanceQuery : IRequest<List<AttendanceDTO>>
    {
        public int Schedule_id { get; set; }
        public GetAttendanceQuery(int Schedule_id)
        {
            this.Schedule_id = Schedule_id;
        }
    }
}
