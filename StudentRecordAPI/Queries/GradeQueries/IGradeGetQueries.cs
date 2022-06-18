using StudentRecordAPI.Models.AddDTO;
using StudentRecordAPI.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentRecordAPI.Queries.GradeQueries
{
    public interface IGradeGetQueries
    {
        Task<List<List<GradeInfoSubjectDTO>>> GetAllGrades();
        Task<List<GradeInfoDTO>> GetGradesFromSubject(int Subject_id);
        Task<float> GetAverageGradeFromSubject(int Subject_id);
        Task<GradeMoreInfoDTO> GetInfoAboutGrade(int Grade_id);
        Task<List<GradeInfoDTO>> GetStudentGradesFromSubject(GradeSubjectDTO gradeandsubjectids);
    }
}
