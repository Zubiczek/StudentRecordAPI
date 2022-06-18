using MediatR;
using StudentRecordAPI.Models.DTO;
using System.Collections.Generic;
namespace StudentRecordAPI.Features.ScheduleFeatures.Queries
{
    public class GetStudentScheduleQuery : IRequest<List<List<ScheduleSubjectDTO>>>
    {
        public int Class_id { get; set; }
        public GetStudentScheduleQuery(int Class_id)
        {
            this.Class_id = Class_id;
        }
    }
}
