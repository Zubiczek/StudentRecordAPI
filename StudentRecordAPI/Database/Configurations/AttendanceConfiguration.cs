using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentRecordAPI.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRecordAPI.Database.Configurations
{
    public class AttendanceConfiguration : IEntityTypeConfiguration<AttendanceEntity>
    {
        public void Configure(EntityTypeBuilder<AttendanceEntity> builder)
        {
            builder.HasKey(x => x.Attendance_Id);
            builder.HasOne(x => x.Student).WithMany(x => x.Attendances).HasForeignKey(x => x.Student_Id);
            builder.HasOne(x => x.Schedule).WithMany(x => x.Attendance).HasForeignKey(x => x.Schedule_Id);
        }
    }
}
