using System.Threading.Tasks;

namespace StudentRecordAPI.Queries.ClassQueries
{
    public interface IClassPostQueries
    {
        Task AddNewStudentToClass(string Student_id, int Class_id);
    }
}
