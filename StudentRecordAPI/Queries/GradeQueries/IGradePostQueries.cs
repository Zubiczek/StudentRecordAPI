using StudentRecordAPI.Models.AddDTO;
using System.Threading.Tasks;

namespace StudentRecordAPI.Queries.GradeQueries
{
    public interface IGradePostQueries
    {
        Task AddNewGrade(GradeAddDTO Grade);
        Task DeleteGrade(int Grade_id);
        Task UpdateGrade(int Grade_id, float Grade);
    }
}
