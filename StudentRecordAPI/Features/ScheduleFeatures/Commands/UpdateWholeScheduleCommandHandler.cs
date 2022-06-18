using MediatR;
using StudentRecordAPI.Queries.ScheduleQueries;
using System.Threading;
using System.Threading.Tasks;

namespace StudentRecordAPI.Features.ScheduleFeatures.Commands
{
    public class UpdateWholeScheduleCommandHandler : IRequestHandler<UpdateWholeScheduleCommand, Unit>
    {
        private readonly ISchedulePostQueries _schedulePostQueries;
        public UpdateWholeScheduleCommandHandler(ISchedulePostQueries schedulePostQueries)
        {
            _schedulePostQueries = schedulePostQueries;
        }
        public async Task<Unit> Handle(UpdateWholeScheduleCommand command, CancellationToken cancellationToken)
        {
            await _schedulePostQueries.UpdateWholeSchedule(command.schedule);
            return Unit.Value;
        }
    }
}
