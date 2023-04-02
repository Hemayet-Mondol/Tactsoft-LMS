using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Entities;

namespace Tactsoft.Data.EntityConfigurations
{
    public class ExamResultConfiguration : IEntityTypeConfiguration<ExamResult>
    {
        public void Configure(EntityTypeBuilder<ExamResult> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Exam).WithMany(x => x.ExamResults).HasForeignKey(x => x.ExamId);
            builder.HasOne(x => x.Student).WithMany(x => x.ExamResults).HasForeignKey(x => x.StudentId);
        }
    }
}
