using MediatR;

namespace StudentRecordAPI.Features.GradeFeatures.Commands
{
    public class DeleteGradeCommand : IRequest
    {
        public int Grade_id { get; set; }
        public DeleteGradeCommand(int Grade_id)
        {
            this.Grade_id = Grade_id;
        }
    }
}
