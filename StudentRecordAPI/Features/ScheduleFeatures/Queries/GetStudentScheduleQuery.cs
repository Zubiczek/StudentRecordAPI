using MediatR;
using StudentRecordAPI.Models.DTO;
using System.Collections.Generic;
namespace StudentRecordAPI.Features.ScheduleFeatures.Queries
{
    public class GetStudentScheduleQuery : IRequest<List<List<ScheduleSubjectDTO>>>
    {
        public uint Class_id { get; set; }
        public GetStudentScheduleQuery(uint Class_id)
        {
            this.Class_id = Class_id;
        }
    }
}
