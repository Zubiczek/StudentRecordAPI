using System;

namespace StudentRecordAPI.Models.DTO
{
    public class NoteDTO
    {
        public uint Note_Id { get; set; }
        public bool isitpositive { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Description { get; set; }
        public string Teacher { get; set; }
    }
}
