using System;

namespace StudentRecordAPI.Models.DTO
{
    public class ScheduleSubjectDTO
    {
        public int Schedule_Id { get; set; }
        public DateTime Date { get; set; }
        public string ClassRoom { get; set; }
        public string Teacher { get; set; }
        public string Subject { get; set; }
    }
}
