using StudentRecordAPI.Models.AddDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentRecordAPI.Queries.ScheduleQueries
{
    public interface ISchedulePostQueries
    {
        Task UpdateWholeSchedule(List<NewScheduleDTO> newschedule);
    }
}
