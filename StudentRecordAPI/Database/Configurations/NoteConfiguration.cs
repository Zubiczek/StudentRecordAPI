using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentRecordAPI.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRecordAPI.Database.Configurations
{
    public class NoteConfiguration : IEntityTypeConfiguration<NoteEntity>
    {
        public void Configure(EntityTypeBuilder<NoteEntity> builder)
        {
            builder.HasKey(x => x.Note_Id);
            builder.HasOne(x => x.Student).WithMany(x => x.StudentNotes).HasForeignKey(x => x.Student_Id);
            builder.HasOne(x => x.Teacher).WithMany(x => x.TeacherNotes).HasForeignKey(x => x.Teacher_Id);
        }
    }
}
