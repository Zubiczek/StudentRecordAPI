﻿using StudentRecordAPI.Models.AddDTO;
using System.Threading.Tasks;

namespace StudentRecordAPI.Queries.NoteQueries
{
    public interface INotePostQueries
    {
        Task AddNote(NoteAddDTO note);
        Task DeleteNote(int Note_id);
    }
}
