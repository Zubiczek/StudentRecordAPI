using System;

namespace StudentRecordAPI.Models.AddDTO
{
    public class NewScheduleDTO
    {
        public DateTime Date { get; set; }
        public string ClassRoom { get; set; }
        public int Class_Id { get; set; }
        public string Teacher_Id { get; set; }
        public int Subject_Id { get; set; }
    }
}
