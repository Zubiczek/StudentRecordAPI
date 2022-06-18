using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRecordAPI.Database.Entities
{
    public class ClassEntity
    {
        public int Class_Id { get; set; }
        [Required]
        [MaxLength(5)]
        public string ClassName { get; set; }
        public virtual List<UserEntity> Students { get; set; }
        public virtual List<ScheduleEntity> Schedules { get; set; }
        public ClassEntity()
        {
            this.Students = new List<UserEntity>();
            this.Schedules = new List<ScheduleEntity>();
        }
    }
}
