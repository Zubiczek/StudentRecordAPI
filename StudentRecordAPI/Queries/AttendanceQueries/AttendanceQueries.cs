using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentRecordAPI.Database;
using StudentRecordAPI.Database.Entities;
using StudentRecordAPI.Models.AddDTO;
using StudentRecordAPI.Models.DTO;
using StudentRecordAPI.Models.Others;
using StudentRecordAPI.Services.LoggedInUserService;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRecordAPI.Queries.AttendanceQueries
{
    public class AttendanceQueries : IAttendanceGetQueries, IAttendancePostQueries
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        private readonly ILoggedInUserService _loggedInUserService;
        public AttendanceQueries(Context context, IMapper mapper, ILoggedInUserService loggedInUserService)
        {
            _context = context;
            _mapper = mapper;
            _loggedInUserService = loggedInUserService;
        }
        public async Task<List<AttendanceDTO>> GetAttendanceListFromSubject(int Schedule_id)
        {
            string userid = _loggedInUserService.GetUserId();
            var attendancelist = await _context.Attendance.Include(x => x.Schedule).ThenInclude(x => x.Subject)
                .Where(x => x.Schedule_Id == Schedule_id && x.Student_Id == userid)
                .Select(x => new AttendanceDTO
                {
                    Attendance_Id = x.Attendance_Id,
                    Present = x.Present,
                    CreatedOn = x.CreatedOn,
                    Subject = x.Schedule.Subject.Subject_Name
                }).AsNoTracking().AsSplitQuery().ToListAsync();
            if (attendancelist == null) throw new HttpResponseException("Attendance list not found!", 404);
            return attendancelist;
        }

        public async Task<float> GetAVGAttendance(int Schedule_id)
        {
            string userid = _loggedInUserService.GetUserId();
            var attendancevalues = await _context.Attendance.Where(x => x.Student_Id == userid && x.Schedule_Id == Schedule_id)
                .Select(x => x.Present).ToListAsync();
            if(attendancevalues == null) throw new HttpResponseException("Attendance list not found!", 404);
            int count = attendancevalues.Count();
            if (count == 0) throw new HttpResponseException("Invalid data, count equals 0", 400);
            int truecount = attendancevalues.Count(x => x == true);
            return (float)(truecount * 100) / count;
        }
        public async Task AddAttendance(AttendanceAddDTO attendance)
        {
            if (attendance == null) throw new HttpResponseException("Incorrect data, model is null", 400);
            AttendanceEntity newattendance = new AttendanceEntity();
            var entity = _mapper.Map<AttendanceAddDTO ,AttendanceEntity>(attendance, newattendance);
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }
    }
}
