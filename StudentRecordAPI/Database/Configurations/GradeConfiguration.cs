using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentRecordAPI.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRecordAPI.Database.Configurations
{
    public class GradeConfiguration : IEntityTypeConfiguration<GradeEntity>
    {
        public void Configure(EntityTypeBuilder<GradeEntity> builder)
        {
            builder.HasKey(x => x.Grade_Id);
            builder.HasOne(x => x.Student).WithMany(x => x.Grades).HasForeignKey(x => x.Student_Id);
            builder.HasOne(x => x.Subject).WithMany(x => x.Grades).HasForeignKey(x => x.Subject_Id);
        }
    }
}
