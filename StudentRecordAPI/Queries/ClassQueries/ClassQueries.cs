using Microsoft.EntityFrameworkCore;
using StudentRecordAPI.Database;
using StudentRecordAPI.Models.DTO;
using StudentRecordAPI.Models.Others;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRecordAPI.Queries.ClassQueries
{
    public class ClassQueries : IClassGetQueries, IClassPostQueries
    {
        private readonly Context _context;
        public ClassQueries(Context context)
        {
            _context = context;
        }
        public async Task<List<StudentsDTO>> GetListOfStudents(int Class_id)
        {
            var students = await _context.User.Where(x => x.Class_Id == Class_id).Select(x => new StudentsDTO
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName
            }).AsNoTracking().ToListAsync();
            if (students == null) throw new HttpResponseException("Students not found! Invalid Class id", 404);
            return students;
        }
        public async Task AddNewStudentToClass(string Student_id, int Class_id)
        {
            var student = await _context.User.Where(x => x.Id == Student_id).FirstOrDefaultAsync();
            if (student == null) throw new HttpResponseException("Student not found! Invalid id", 404);
            var Class = await _context.Class.Where(x => x.Class_Id == Class_id).FirstOrDefaultAsync();
            if (Class == null) throw new HttpResponseException("Class not found! Invalid id", 404);
            student.Class_Id = Class_id;
            await _context.SaveChangesAsync();
        }
    }
}
