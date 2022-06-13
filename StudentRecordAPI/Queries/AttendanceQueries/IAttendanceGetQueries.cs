using StudentRecordAPI.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentRecordAPI.Queries.AttendanceQueries
{
    public interface IAttendanceGetQueries
    {
        Task<List<AttendanceDTO>> GetAttendanceListFromSubject(uint Schedule_id);
        Task<float> GetAVGAttendance(uint Schedule_id);
    }
}
