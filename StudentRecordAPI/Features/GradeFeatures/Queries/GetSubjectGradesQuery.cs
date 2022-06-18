using MediatR;
using StudentRecordAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRecordAPI.Features.GradeFeatures.Queries
{
    public class GetSubjectGradesQuery : IRequest<List<GradeInfoDTO>>
    {
        public int Subject_id { get; set; }
        public GetSubjectGradesQuery(int Subject_id)
        {
            this.Subject_id = Subject_id;
        }
    }
}
