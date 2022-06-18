using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRecordAPI.Database.Entities
{
    public class GradeEntity
    {
        public int Grade_Id { get; set; }
        [Range(1, 6)]
        public float Grade { get; set; }
        [MaxLength(50)]
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Student_Id { get; set; }
        public int Subject_Id { get; set; }
        public virtual UserEntity Student { get; set; }
        public virtual SubjectEntity Subject { get; set; }
        public GradeEntity()
        {
            this.CreatedOn = DateTime.UtcNow;
        }
    }
}
