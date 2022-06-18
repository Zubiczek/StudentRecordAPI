using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRecordAPI.Features.GradeFeatures.Queries
{
    public class GetGradesAVGQuery : IRequest<float>
    {
        public int Subject_id { get; set; }
        public GetGradesAVGQuery(int Subject_id)
        {
            this.Subject_id = Subject_id;
        }
    }
}
