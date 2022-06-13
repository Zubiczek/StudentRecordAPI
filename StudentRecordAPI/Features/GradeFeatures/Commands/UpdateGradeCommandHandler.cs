using MediatR;
using StudentRecordAPI.Queries.GradeQueries;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudentRecordAPI.Features.GradeFeatures.Commands
{
    public class UpdateGradeCommandHandler : IRequestHandler<UpdateGradeCommand, Unit>
    {
        private readonly IGradePostQueries _gradePostQueries;
        public UpdateGradeCommandHandler(IGradePostQueries gradePostQueries)
        {
            _gradePostQueries = gradePostQueries ?? throw new ArgumentNullException();
        }
        public async Task<Unit> Handle(UpdateGradeCommand command, CancellationToken cancellationToken)
        {
            await _gradePostQueries.UpdateGrade(command.Grade_id, command.Grade);
            return Unit.Value;
        }
    }
}
