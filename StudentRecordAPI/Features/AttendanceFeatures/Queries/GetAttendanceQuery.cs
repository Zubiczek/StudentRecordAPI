using MediatR;
using StudentRecordAPI.Models.DTO;
using System.Collections.Generic;

namespace StudentRecordAPI.Features.AttendanceFeatures.Queries
{
    public class GetAttendanceQuery : IRequest<List<AttendanceDTO>>
    {
        public uint Schedule_id { get; set; }
        public GetAttendanceQuery(uint Schedule_id)
        {
            this.Schedule_id = Schedule_id;
        }
    }
}
