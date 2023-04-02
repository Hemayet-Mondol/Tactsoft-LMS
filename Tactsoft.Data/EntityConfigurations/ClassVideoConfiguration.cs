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
    public class ClassVideoConfiguration : IEntityTypeConfiguration<ClassVideo>
    {
        public void Configure(EntityTypeBuilder<ClassVideo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Lesson).WithMany(x => x.ClassVideos).HasForeignKey(x => x.LessonId);
        }
    }
}
