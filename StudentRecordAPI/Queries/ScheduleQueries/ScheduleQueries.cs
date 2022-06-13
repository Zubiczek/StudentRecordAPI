using Microsoft.EntityFrameworkCore;
using StudentRecordAPI.Database;
using StudentRecordAPI.Models.DTO;
using StudentRecordAPI.Models.Others;
using StudentRecordAPI.Services.LoggedInUserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRecordAPI.Queries.ScheduleQueries
{
    public class ScheduleQueries : IScheduleGetQueries
    {
        private readonly Context _context;
        private readonly ILoggedInUserService _loggedInUserService;
        public ScheduleQueries(Context context, ILoggedInUserService loggedInUserService)
        {
            _context = context;
            _loggedInUserService = loggedInUserService;
        }
        public async Task<List<List<ScheduleSubjectDTO>>> GetWholeStudentSchedule(uint Class_id)
        {
            var schedulelist = await _context.Schedule.Include(x => x.Subject)
                .Where(x => x.Class_Id == Class_id).GroupBy(x => x.Date.DayOfWeek).AsNoTracking().AsSplitQuery().ToListAsync();
            if (schedulelist == null) throw new HttpResponseException("Schedule not found! Invalid class id", 404);
            List<List<ScheduleSubjectDTO>> groupedschedule = new List<List<ScheduleSubjectDTO>>();
            List<ScheduleSubjectDTO> dayschedule = new List<ScheduleSubjectDTO>();
            foreach(var schedulegroup in schedulelist)
            {
                foreach(var schedule in schedulegroup)
                {
                    dayschedule.Add(new ScheduleSubjectDTO
                    {
                        Schedule_Id = schedule.Schedule_Id,
                        Date = schedule.Date,
                        ClassRoom = schedule.ClassRoom,
                        Subject = schedule.Subject.Subject_Name
                    });
                }
                groupedschedule.Add(dayschedule.OrderBy(x => x.Date.TimeOfDay).ToList());
                dayschedule.Clear();
            }
            return groupedschedule;
        }
        public async Task<List<ScheduleSubjectDTO>> GetClassScheduleByDate(uint Class_id, DayOfWeek dayOfWeek)
        {
            var schedulelist = await _context.Schedule.Include(x => x.Teacher).Include(x => x.Subject)
                .Where(x => x.Class_Id == Class_id && x.Date.DayOfWeek == dayOfWeek).OrderBy(x => x.Date.TimeOfDay)
                .Select(x => new ScheduleSubjectDTO
                {
                    Schedule_Id = x.Schedule_Id,
                    Date = x.Date,
                    ClassRoom = x.ClassRoom,
                    Teacher = x.Teacher.FirstName + " " + x.Teacher.LastName,
                    Subject = x.Subject.Subject_Name
                }).AsNoTracking().AsSplitQuery().ToListAsync();
            if (schedulelist == null) throw new HttpResponseException("Schedule not found! Invalid data", 404);
            return schedulelist;
        }
        public async Task<ScheduleSubjectDTO> GetNextScheduleSubject(uint Class_id)
        {
            DateTime currentdate = DateTime.UtcNow;
            var schedule = await _context.Schedule.Include(x => x.Teacher).Include(x => x.Subject)
                .Where(x => x.Class_Id == Class_id && x.Date.DayOfWeek == currentdate.DayOfWeek).OrderBy(x => x.Date.TimeOfDay)
                .Select(x => new ScheduleSubjectDTO
                {
                    Schedule_Id = x.Schedule_Id,
                    Date = x.Date,
                    ClassRoom = x.ClassRoom,
                    Teacher = x.Teacher.FirstName + " " + x.Teacher.LastName,
                    Subject = x.Subject.Subject_Name
                }).AsNoTracking().AsSplitQuery().ToListAsync();
            if(schedule == null) throw new HttpResponseException("Schedule not found! Invalid data", 404);
            currentdate = DateTime.UtcNow;
            ScheduleSubjectDTO nextsubject = null;
            foreach(var subject in schedule)
            {
                if(subject.Date.Hour > currentdate.Hour)
                {
                    nextsubject = subject;
                    break;
                }
                else if(subject.Date.Hour == currentdate.Hour)
                {
                    if(subject.Date.Minute > currentdate.Minute)
                    {
                        nextsubject = subject;
                        break;
                    }
                }
            }
            if (nextsubject == null) throw new HttpResponseException("Subject not found!", 404);
            return nextsubject;
        }
        public async Task<List<TeacherScheduleDTO>> GetTodayTeacherSchedule()
        {
            string teacherid = _loggedInUserService.GetUserId();
            DateTime currentdate = DateTime.UtcNow;
            var schedule = await _context.Schedule.Include(x => x.Class).Include(x => x.Subject)
                .Where(x => x.Teacher_Id == teacherid && x.Date.DayOfWeek == currentdate.DayOfWeek)
                .Select(x => new TeacherScheduleDTO
                {
                    Schedule_Id = x.Schedule_Id,
                    Date = x.Date,
                    ClassRoom = x.ClassRoom,
                    Class_Id = x.Class_Id,
                    Class_Name = x.Class.ClassName,
                    Subject_Id = x.Subject_Id,
                    Subject_Name = x.Subject.Subject_Name
                }).AsNoTracking().AsSplitQuery().ToListAsync();
            if (schedule == null) throw new HttpResponseException("Schedule not found!", 404);
            return schedule;
        }
    }
}
