using StudentRecordAPI.Models.AddDTO;
using System.Threading.Tasks;

namespace StudentRecordAPI.Queries.GradeQueries
{
    public interface IGradePostQueries
    {
        Task AddNewGrade(GradeAddDTO Grade);
        Task DeleteGrade(uint Grade_id);
        Task UpdateGrade(uint Grade_id, float Grade);
    }
}
