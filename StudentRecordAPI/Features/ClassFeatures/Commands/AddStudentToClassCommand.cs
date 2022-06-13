using MediatR;

namespace StudentRecordAPI.Features.ClassFeatures.Commands
{
    public class AddStudentToClassCommand : IRequest
    {
        public string Student_id { get; set; }
        public uint Class_id { get; set; }
        public AddStudentToClassCommand(string Student_id, uint Class_id)
        {
            this.Student_id = Student_id;
            this.Class_id = Class_id;
        }
    }
}
