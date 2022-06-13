using MediatR;
using StudentRecordAPI.Models.DTO;
using System.Collections.Generic;

namespace StudentRecordAPI.Features.ScheduleFeatures.Queries
{
    public class GetTeacherScheduleQuery : IRequest<List<TeacherScheduleDTO>>
    {

    }
}
