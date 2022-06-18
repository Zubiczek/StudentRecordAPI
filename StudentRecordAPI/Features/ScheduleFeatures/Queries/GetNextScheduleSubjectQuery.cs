using MediatR;
using StudentRecordAPI.Models.DTO;

namespace StudentRecordAPI.Features.ScheduleFeatures.Queries
{
    public class GetNextScheduleSubjectQuery : IRequest<ScheduleSubjectDTO>
    {
        public int Class_id { get; set; }
        public GetNextScheduleSubjectQuery(int Class_id)
        {
            this.Class_id = Class_id;
        }
    }
}
