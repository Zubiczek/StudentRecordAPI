using MediatR;
using StudentRecordAPI.Models.DTO;
using System.Collections.Generic;

namespace StudentRecordAPI.Features.ClassFeatures.Queries
{
    public class GetClassStudentsQuery : IRequest<List<StudentsDTO>>
    {
        public uint Class_id { get; set; }
        public GetClassStudentsQuery(uint Class_id)
        {
            this.Class_id = Class_id;
        }
    }
}
