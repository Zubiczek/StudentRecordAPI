using MediatR;

namespace StudentRecordAPI.Features.GradeFeatures.Commands
{
    public class DeleteGradeCommand : IRequest
    {
        public uint Grade_id { get; set; }
        public DeleteGradeCommand(uint Grade_id)
        {
            this.Grade_id = Grade_id;
        }
    }
}
