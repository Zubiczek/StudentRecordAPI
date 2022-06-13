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

namespace StudentRecordAPI.Queries.GradeQueries
{
    public class GradeQueries : IGradeGetQueries, IGradePostQueries
    {
        private readonly Context _context;
        private readonly ILoggedInUserService _loggedInUserService;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public GradeQueries(Context context, ILoggedInUserService loggedInUserService, IValidationService validationService,
            IMapper mapper)
        {
            _context = context;
            _loggedInUserService = loggedInUserService;
            _validationService = validationService;
            _mapper = mapper;
        }
        public async Task<List<List<GradeInfoSubjectDTO>>> GetAllGrades()
        {
            string userid = _loggedInUserService.GetUserId();
            var grades = await _context.Grade.Include(x => x.Subject).Where(x => x.Student_Id == userid)
                .GroupBy(x => x.Subject.Subject_Name).AsSplitQuery().AsNoTracking().ToListAsync();
            if (grades == null) throw new HttpResponseException("Grades not found", 404);
            List<List<GradeInfoSubjectDTO>> gradesbysubject = new List<List<GradeInfoSubjectDTO>>();
            List<GradeInfoSubjectDTO> subjectgrades = new List<GradeInfoSubjectDTO>();
            foreach(var subjectgroup in grades)
            {
                foreach(var grade in subjectgroup)
                {
                    subjectgrades.Add(new GradeInfoSubjectDTO
                    {
                        Grade_Id = grade.Grade_Id,
                        Grade = grade.Grade,
                        SubjectName = subjectgroup.Key
                    });
                }
                gradesbysubject.Add(subjectgrades);
                subjectgrades.Clear();
            }
            return gradesbysubject;
        }

        public async Task<float> GetAverageGradeFromSubject(uint Subject_id)
        {
            string userid = _loggedInUserService.GetUserId();
            float gradeavg = 0;
            gradeavg = await _context.Grade.Where(x => x.Student_Id == userid && x.Subject_Id == Subject_id)
                .AverageAsync(x => x.Grade);
            if (gradeavg == 0) throw new HttpResponseException("Grades not found or invalid subject", 404);
            return gradeavg;
        }

        public async Task<List<GradeInfoDTO>> GetGradesFromSubject(uint Subject_id)
        {
            string userid = _loggedInUserService.GetUserId();
            var grades = await _context.Grade.Where(x => x.Student_Id == userid && x.Subject_Id == Subject_id)
                .Select(x => new GradeInfoDTO
                {
                    Grade_Id = x.Grade_Id,
                    Grade = x.Grade
                }).AsNoTracking().ToListAsync();
            if (grades == null) throw new HttpResponseException("Grades not found!", 404);
            return grades;
        }

        public async Task<GradeMoreInfoDTO> GetInfoAboutGrade(uint Grade_id)
        {
            var gradeinfo = await _context.Grade.Include(x => x.Subject).Where(x => x.Grade_Id == Grade_id)
                .Select(x => new GradeMoreInfoDTO
                {
                    Grade_Id = x.Grade_Id,
                    Grade = x.Grade,
                    Description = x.Description,
                    CreatedOn = x.CreatedOn,
                    SubjectName = x.Subject.Subject_Name
                }).AsSplitQuery().AsNoTracking().FirstOrDefaultAsync();
            if(gradeinfo == null) throw new HttpResponseException("The Grade was not found!", 404);
            return gradeinfo;
        }
        public async Task<List<GradeInfoDTO>> GetStudentGradesFromSubject(GradeSubjectDTO gradeandsubjectids)
        {
            var grades = await _context.Grade.
                Where(x => x.Student_Id == gradeandsubjectids.Student_id && x.Subject_Id == gradeandsubjectids.Subject_id)
                .Select(x => new GradeInfoDTO
                {
                    Grade_Id = x.Grade_Id,
                    Grade = x.Grade
                }).AsNoTracking().ToListAsync();
            if (grades == null) throw new HttpResponseException("Grades were not found, invalid id", 404);
            return grades;
        }
        public async Task AddNewGrade(GradeAddDTO Grade)
        {
            var newgrade = _mapper.Map<GradeEntity>(Grade);
            var validationresult = _validationService.Validate(newgrade);
            if (!validationresult.Item1) throw new HttpResponseException(validationresult.Item2, 400);
            _context.Add(newgrade);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGrade(uint Grade_id)
        {
            var grade = await _context.Grade.Where(x => x.Grade_Id == Grade_id).FirstOrDefaultAsync();
            if (grade == null) throw new HttpResponseException("The Grade was not found!", 404);
            _context.Remove(grade);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateGrade(uint Grade_id, float Grade)
        {
            if (Grade < 1 || Grade > 6) throw new HttpResponseException("Invalid Grade!", 400);
            var grademodel = await _context.Grade.Where(x => x.Grade_Id == Grade_id).FirstOrDefaultAsync();
            if (grademodel == null) throw new HttpResponseException("Grade was not found, invalid id!", 404);
            grademodel.Grade = Grade;
            await _context.SaveChangesAsync();
        }
    }
}
