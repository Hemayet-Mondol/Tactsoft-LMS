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
    public class AssingmentConfiguration : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Batch).WithMany(x => x.Assignments).HasForeignKey(x => x.BatchId);
            builder.HasOne(x => x.Course).WithMany(x => x.Assignments).HasForeignKey(x => x.CourseId);
        }
    }
}
