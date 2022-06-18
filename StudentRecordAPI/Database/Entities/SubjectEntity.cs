using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRecordAPI.Database.Entities
{
    public class SubjectEntity
    {
        public int Subject_Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Subject_Name { get; set; }
        public virtual List<GradeEntity> Grades { get; set; }
        public virtual List<ScheduleEntity> Schedules { get; set; }
        public SubjectEntity()
        {
            this.Grades = new List<GradeEntity>();
            this.Schedules = new List<ScheduleEntity>();
        }
    }
}
