using MediatR;
using StudentRecordAPI.Models.AddDTO;

namespace StudentRecordAPI.Features.GradeFeatures.Commands
{
    public class AddGradeCommand : IRequest
    {
        public GradeAddDTO Grade { get; set; }
        public AddGradeCommand(GradeAddDTO Grade)
        {
            this.Grade = Grade;
        }
    }
}
