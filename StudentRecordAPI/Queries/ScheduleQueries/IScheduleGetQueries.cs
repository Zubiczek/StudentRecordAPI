using StudentRecordAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentRecordAPI.Queries.ScheduleQueries
{
    public interface IScheduleGetQueries
    {
        Task<List<List<ScheduleSubjectDTO>>> GetWholeStudentSchedule(uint Class_id);
        Task<List<ScheduleSubjectDTO>> GetClassScheduleByDate(uint Class_id, DayOfWeek dayOfWeek);
        Task<ScheduleSubjectDTO> GetNextScheduleSubject(uint Class_id);
        Task<List<TeacherScheduleDTO>> GetTodayTeacherSchedule();
    }
}
