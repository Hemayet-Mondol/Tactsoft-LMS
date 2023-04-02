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
    public class LinkConfiguration:IEntityTypeConfiguration<Link>
    {
        public void Configure(EntityTypeBuilder<Link> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Batch).WithMany(x => x.Links).HasForeignKey(x => x.BatchId);
            builder.HasOne(x => x.Course).WithMany(x => x.Links).HasForeignKey(x => x.CourseId);

        }
    }
}
