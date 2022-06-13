using MediatR;
using StudentRecordAPI.Models.DTO;

namespace StudentRecordAPI.Features.ScheduleFeatures.Queries
{
    public class GetNextScheduleSubjectQuery : IRequest<ScheduleSubjectDTO>
    {
        public uint Class_id { get; set; }
        public GetNextScheduleSubjectQuery(uint Class_id)
        {
            this.Class_id = Class_id;
        }
    }
}
