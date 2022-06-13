using System;

namespace StudentRecordAPI.Models.DTO
{
    public class TeacherScheduleDTO
    {
        public uint Schedule_Id { get; set; }
        public DateTime Date { get; set; }
        public string ClassRoom { get; set; }
        public uint Class_Id { get; set; }
        public string Class_Name { get; set; }
        public uint Subject_Id { get; set; }
        public string Subject_Name { get; set; }
    }
}
