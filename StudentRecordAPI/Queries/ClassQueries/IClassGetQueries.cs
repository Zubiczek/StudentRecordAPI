using StudentRecordAPI.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentRecordAPI.Queries.ClassQueries
{
    public interface IClassGetQueries
    {
        Task<List<StudentsDTO>> GetListOfStudents(int Class_id);
    }
}
