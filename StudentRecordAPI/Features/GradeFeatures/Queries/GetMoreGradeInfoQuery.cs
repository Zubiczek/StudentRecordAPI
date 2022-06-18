using MediatR;
using StudentRecordAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRecordAPI.Features.GradeFeatures.Queries
{
    public class GetMoreGradeInfoQuery : IRequest<GradeMoreInfoDTO>
    {
        public int Grade_id { get; set; }
        public GetMoreGradeInfoQuery(int Grade_id)
        {
            this.Grade_id = Grade_id;
        }
    }
}
