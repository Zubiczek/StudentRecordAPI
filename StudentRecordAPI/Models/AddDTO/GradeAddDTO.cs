using System;
using System.ComponentModel.DataAnnotations;

namespace StudentRecordAPI.Models.AddDTO
{
    public class GradeAddDTO
    {
        [Range(1, 6)]
        public float Grade { get; set; }
        [MaxLength(50)]
        public string Description { get; set; }
        public string Student_Id { get; set; }
        public uint Subject_Id { get; set; }
    }
}
