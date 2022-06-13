using MediatR;
using StudentRecordAPI.Queries.AttendanceQueries;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudentRecordAPI.Features.AttendanceFeatures.Commands
{
    public class AddAttendanceCommandHandler : IRequestHandler<AddAttendanceCommand, Unit>
    {
        private readonly IAttendancePostQueries _attendanceQueries;
        public AddAttendanceCommandHandler(IAttendancePostQueries attendancePostQueries)
        {
            _attendanceQueries = attendancePostQueries ?? throw new ArgumentNullException();
        }
        public async Task<Unit> Handle(AddAttendanceCommand command, CancellationToken cancellationToken)
        {
            await _attendanceQueries.AddAttendance(command.attendance);
            return Unit.Value;
        }
    }
}
