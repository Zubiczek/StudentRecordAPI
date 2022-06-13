using StudentRecordAPI.Models.AddDTO;
using System.Threading.Tasks;

namespace StudentRecordAPI.Queries.AttendanceQueries
{
    public interface IAttendancePostQueries
    {
        Task AddAttendance(AttendanceAddDTO attendance);
    }
}
