using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentRecordAPI.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRecordAPI.Database
{
    public class Context : IdentityDbContext
    {
        public Context(DbContextOptions<Context> options) :base(options)
        {

        }
        public DbSet<AttendanceEntity> Attendance { get; set; }
        public DbSet<ClassEntity> Class { get; set; }
        public DbSet<GradeEntity> Grade { get; set; }
        public DbSet<NoteEntity> Note { get; set; }
        public DbSet<ScheduleEntity> Schedule { get; set; }
        public DbSet<SubjectEntity> Subject { get; set; }
        public DbSet<UserEntity> User { get; set; }
        public DbSet<RefreshTokenEntity> RefreshToken { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyAllConfigurations();
        }
    }
}
