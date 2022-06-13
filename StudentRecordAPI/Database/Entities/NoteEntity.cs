using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRecordAPI.Database.Entities
{
    public class NoteEntity
    {
        public uint Note_Id { get; set; }
        [DefaultValue(false)]
        public bool isitpositive { get; set; }
        public DateTime CreatedOn { get; set; }
        [Required]
        [MaxLength(150)]
        public string Description { get; set; }
        public string Student_Id { get; set; }
        public string Teacher_Id { get; set; }
        public virtual UserEntity Student { get; set; }
        public virtual UserEntity Teacher { get; set; }
        public NoteEntity()
        {
            this.CreatedOn = DateTime.UtcNow;
        }
    }
}
