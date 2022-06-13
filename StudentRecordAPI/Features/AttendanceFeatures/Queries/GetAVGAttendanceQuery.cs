using MediatR;

namespace StudentRecordAPI.Features.AttendanceFeatures.Queries
{
    public class GetAVGAttendanceQuery : IRequest<float>
    {
        public uint Schedule_id { get; set; }
        public GetAVGAttendanceQuery(uint Schedule_id)
        {
            this.Schedule_id = Schedule_id;
        }
    }
}
