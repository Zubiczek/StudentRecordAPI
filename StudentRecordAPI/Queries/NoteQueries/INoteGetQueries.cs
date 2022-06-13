using StudentRecordAPI.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentRecordAPI.Queries.NoteQueries
{
    public interface INoteGetQueries
    {
        Task<List<NoteDTO>> GetStudentNotes();
    }
}
