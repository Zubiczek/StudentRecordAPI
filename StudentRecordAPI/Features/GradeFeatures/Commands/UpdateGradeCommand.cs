using MediatR;

namespace StudentRecordAPI.Features.GradeFeatures.Commands
{
    public class UpdateGradeCommand : IRequest
    {
        public int Grade_id { get; set; }
        public float Grade { get; set; }
        public UpdateGradeCommand(int Grade_id, float Grade)
        {
            this.Grade_id = Grade_id;
            this.Grade = Grade;
        }
    }
}
