using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentRecordAPI.Database;
using StudentRecordAPI.Database.Entities;
using StudentRecordAPI.Models.AddDTO;
using StudentRecordAPI.Models.DTO;
using StudentRecordAPI.Models.Others;
using StudentRecordAPI.Services.LoggedInUserService;
using StudentRecordAPI.Services.ValidationService;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRecordAPI.Queries.NoteQueries
{
    public class NoteQueries : INoteGetQueries, INotePostQueries
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        private readonly ILoggedInUserService _loggedInUserService;
        private readonly IValidationService _validationService;
        public NoteQueries(Context context, IMapper mapper, ILoggedInUserService loggedInUserService,
            IValidationService validationService)
        {
            _context = context;
            _mapper = mapper;
            _loggedInUserService = loggedInUserService;
            _validationService = validationService;
        }
        public async Task<List<NoteDTO>> GetStudentNotes()
        {
            string studentid = _loggedInUserService.GetUserId();
            var notes = await _context.Note.Include(x => x.Teacher).Where(x => x.Student_Id == studentid)
                .Select(x => new NoteDTO
                {
                    Note_Id = x.Note_Id,
                    isitpositive = x.isitpositive,
                    CreatedOn = x.CreatedOn,
                    Description = x.Description,
                    Teacher = x.Teacher.FirstName + " " + x.Teacher.LastName
                }).AsNoTracking().AsSplitQuery().ToListAsync();
            if (notes == null) throw new HttpResponseException("Notes not found!", 404);
            return notes;
        }
        public async Task AddNote(NoteAddDTO note)
        {
            if (note == null) throw new HttpResponseException("Invalid data - model null", 400);
            var validationresult = _validationService.Validate(note);
            if (!validationresult.Item1) throw new HttpResponseException(validationresult.Item2, 400);
            NoteEntity newnote = new NoteEntity();
            var noteentity = _mapper.Map<NoteAddDTO, NoteEntity>(note, newnote);
            _context.Add(noteentity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteNote(uint Note_id)
        {
            var note = await _context.Note.Where(x => x.Note_Id == Note_id).FirstOrDefaultAsync();
            if (note == null) throw new HttpResponseException("Note not found with given id", 404);
            _context.Remove(note);
            await _context.SaveChangesAsync();
        }
    }
}
