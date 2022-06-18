using System;
using System.ComponentModel.DataAnnotations;

namespace StudentRecordAPI.Models.AddDTO
{
    public class NoteAddDTO
    {
        public bool isitpositive { get; set; }
        [Required]
        [MaxLength(150)]
        public string Description { get; set; }
        public string Student_Id { get; set; }
        public string Teacher_Id { get; set; }
    }
}
