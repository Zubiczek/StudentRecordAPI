using MediatR;

namespace StudentRecordAPI.Features.AttendanceFeatures.Queries
{
    public class GetAVGAttendanceQuery : IRequest<float>
    {
        public int Schedule_id { get; set; }
        public GetAVGAttendanceQuery(int Schedule_id)
        {
            this.Schedule_id = Schedule_id;
        }
    }
}
