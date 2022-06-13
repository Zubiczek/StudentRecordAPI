using MediatR;
using StudentRecordAPI.Queries.GradeQueries;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudentRecordAPI.Features.GradeFeatures.Commands
{
    public class AddGradeCommandHandler : IRequestHandler<AddGradeCommand, Unit>
    {
        private readonly IGradePostQueries _gradePostQueries;
        public AddGradeCommandHandler(IGradePostQueries gradePostQueries)
        {
            _gradePostQueries = gradePostQueries ?? throw new ArgumentNullException();
        }
        public async Task<Unit> Handle(AddGradeCommand command, CancellationToken cancellationToken)
        {
            await _gradePostQueries.AddNewGrade(command.Grade);
            return Unit.Value;
        }
    }
}
