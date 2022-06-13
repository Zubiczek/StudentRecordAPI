using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRecordAPI.Database.Entities
{
    public class UserEntity : IdentityUser
    {
        [Required]
        [MaxLength(20, ErrorMessage = "Imię zawiera zbyt dużo znaków!")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "Nazwisko zawiera zbyt dużo znaków!")]
        public string LastName { get; set; }
        public DateTime CreatedOn { get; set; }
        [DefaultValue(false)]
        public bool IsTeacher { get; set; } = false;
        [DefaultValue(false)]
        public bool IsAdmin { get; set; } = false;
        public uint Class_Id { get; set; }
        public virtual ClassEntity Class { get; set; }
        public virtual List<GradeEntity> Grades { get; set; }
        public virtual List<ScheduleEntity> Schedules { get; set; }
        public virtual List<NoteEntity> StudentNotes { get; set; }
        public virtual List<NoteEntity> TeacherNotes { get; set; }
        public virtual List<AttendanceEntity> Attendances { get; set; }
        public UserEntity()
        {
            this.CreatedOn = DateTime.UtcNow;
            this.Grades = new List<GradeEntity>();
            this.Schedules = new List<ScheduleEntity>();
            this.StudentNotes = new List<NoteEntity>();
            this.TeacherNotes = new List<NoteEntity>();
        }
    }
    
}
