using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentRecordAPI.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRecordAPI.Database.Configurations
{
    public class ScheduleConfiguration : IEntityTypeConfiguration<ScheduleEntity>
    {
        public void Configure(EntityTypeBuilder<ScheduleEntity> builder)
        {
            builder.HasKey(x => x.Schedule_Id);
            builder.HasOne(x => x.Class).WithMany(x => x.Schedules).HasForeignKey(x => x.Class_Id);
            builder.HasOne(x => x.Teacher).WithMany(x => x.Schedules).HasForeignKey(x => x.Teacher_Id);
            builder.HasOne(x => x.Subject).WithMany(x => x.Schedules).HasForeignKey(x => x.Subject_Id);
        }
    }
}
