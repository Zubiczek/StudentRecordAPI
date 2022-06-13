using MediatR;
using StudentRecordAPI.Queries.ClassQueries;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudentRecordAPI.Features.ClassFeatures.Commands
{
    public class AddStudentToClassCommandHandler : IRequestHandler<AddStudentToClassCommand, Unit>
    {
        private readonly IClassPostQueries _classPostQueries;
        public AddStudentToClassCommandHandler(IClassPostQueries classPostQueries)
        {
            _classPostQueries = classPostQueries ?? throw new ArgumentNullException();
        }
        public async Task<Unit> Handle(AddStudentToClassCommand command, CancellationToken cancellationToken)
        {
            await _classPostQueries.AddNewStudentToClass(command.Student_id, command.Class_id);
            return Unit.Value;
        }
    }
}
