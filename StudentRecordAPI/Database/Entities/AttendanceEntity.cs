using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace StudentRecordAPI.Database.Entities
{
    public class AttendanceEntity
    {
        public int Attendance_Id { get; set; }
        [DefaultValue(true)]
        public bool Present { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Student_Id { get; set; }
        public int Schedule_Id { get; set; }
        public virtual UserEntity Student { get; set; }
        public virtual ScheduleEntity Schedule { get; set; }
        public AttendanceEntity()
        {
            this.CreatedOn = DateTime.UtcNow;
        }
    }
}
