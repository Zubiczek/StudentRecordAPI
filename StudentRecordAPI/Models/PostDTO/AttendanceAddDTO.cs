using System;

namespace StudentRecordAPI.Models.AddDTO
{
    public class AttendanceAddDTO
    {
        public bool Present { get; set; }
        public string Student_Id { get; set; }
        public int Schedule_Id { get; set; }
    }
}
