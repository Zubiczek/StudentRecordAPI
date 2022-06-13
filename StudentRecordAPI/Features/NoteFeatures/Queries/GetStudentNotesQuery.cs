using MediatR;
using StudentRecordAPI.Models.DTO;
using System.Collections.Generic;

namespace StudentRecordAPI.Features.NoteFeatures.Queries
{
    public class GetStudentNotesQuery : IRequest<List<NoteDTO>>
    {

    }
}
