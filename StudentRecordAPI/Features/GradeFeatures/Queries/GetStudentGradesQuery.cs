using MediatR;
using StudentRecordAPI.Models.AddDTO;
using StudentRecordAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRecordAPI.Features.GradeFeatures.Queries
{
    public class GetStudentGradesQuery : IRequest<List<GradeInfoDTO>>
    {
        public GradeSubjectDTO gradeandsubjectids { get; set; }
        public GetStudentGradesQuery(GradeSubjectDTO gradeandsubjectids)
        {
            this.gradeandsubjectids = gradeandsubjectids;
        }
    }
}
