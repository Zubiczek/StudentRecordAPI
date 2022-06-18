using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRecordAPI.Database.Entities
{
    public class ScheduleEntity
    {
        public int Schedule_Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        [MaxLength(5)]
        public string ClassRoom { get; set; }
        public int Class_Id { get; set; }
        public string Teacher_Id { get; set; }
        public int Subject_Id { get; set; }
        public virtual ClassEntity Class { get; set; }
        public virtual UserEntity Teacher { get; set; }
        public virtual SubjectEntity Subject { get; set; }
        public virtual List<AttendanceEntity> Attendance { get; set; }
        public ScheduleEntity()
        {
            this.Attendance = new List<AttendanceEntity>();
        }
    }
}
