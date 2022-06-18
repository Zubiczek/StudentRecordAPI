using System;

namespace StudentRecordAPI.Models.DTO
{
    public class TeacherScheduleDTO
    {
        public int Schedule_Id { get; set; }
        public DateTime Date { get; set; }
        public string ClassRoom { get; set; }
        public int Class_Id { get; set; }
        public string Class_Name { get; set; }
        public int Subject_Id { get; set; }
        public string Subject_Name { get; set; }
    }
}
