using StudentRecordAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentRecordAPI.Queries.ScheduleQueries
{
    public interface IScheduleGetQueries
    {
        Task<List<List<ScheduleSubjectDTO>>> GetWholeStudentSchedule(int Class_id);
        Task<List<ScheduleSubjectDTO>> GetClassScheduleByDate(int Class_id, DayOfWeek dayOfWeek);
        Task<ScheduleSubjectDTO> GetNextScheduleSubject(int Class_id);
        Task<List<TeacherScheduleDTO>> GetTodayTeacherSchedule();
    }
}
