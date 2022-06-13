using MediatR;
using StudentRecordAPI.Models.AddDTO;

namespace StudentRecordAPI.Features.AttendanceFeatures.Commands
{
    public class AddAttendanceCommand : IRequest
    {
        public AttendanceAddDTO attendance { get; set; }
        public AddAttendanceCommand(AttendanceAddDTO attendance)
        {
            this.attendance = attendance;
        }
    }
}
