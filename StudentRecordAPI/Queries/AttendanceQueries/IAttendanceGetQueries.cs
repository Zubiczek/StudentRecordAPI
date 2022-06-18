using StudentRecordAPI.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentRecordAPI.Queries.AttendanceQueries
{
    public interface IAttendanceGetQueries
    {
        Task<List<AttendanceDTO>> GetAttendanceListFromSubject(int Schedule_id);
        Task<float> GetAVGAttendance(int Schedule_id);
    }
}
