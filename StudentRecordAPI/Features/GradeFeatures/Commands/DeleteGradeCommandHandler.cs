using MediatR;
using StudentRecordAPI.Queries.GradeQueries;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudentRecordAPI.Features.GradeFeatures.Commands
{
    public class DeleteGradeCommandHandler : IRequestHandler<DeleteGradeCommand, Unit>
    {
        private readonly IGradePostQueries _gradePostQueries;
        public DeleteGradeCommandHandler(IGradePostQueries gradePostQueries)
        {
            _gradePostQueries = gradePostQueries ?? throw new ArgumentNullException();
        }
        public async Task<Unit> Handle(DeleteGradeCommand command, CancellationToken cancellationToken)
        {
            await _gradePostQueries.DeleteGrade(command.Grade_id);
            return Unit.Value;
        }
    }
}
