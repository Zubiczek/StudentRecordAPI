using System;

namespace StudentRecordAPI.Models.DTO
{
    public class GradeMoreInfoDTO
    {
        public uint Grade_Id { get; set; }
        public float Grade { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public string SubjectName { get; set; }
    }
}
