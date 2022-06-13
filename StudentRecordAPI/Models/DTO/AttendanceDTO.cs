using System;

namespace StudentRecordAPI.Models.DTO
{
    public class AttendanceDTO
    {
        public uint Attendance_Id { get; set; }
        public bool Present { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Subject { get; set; }
    }
}
