using MediatR;
using StudentRecordAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRecordAPI.Features.GradeFeatures.Queries
{
    public class GetAllGradesQuery : IRequest<List<List<GradeInfoSubjectDTO>>>
    {

    }
}
