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
    public class AttendenceConfiguration : IEntityTypeConfiguration<Attendence>
    {
        public void Configure(EntityTypeBuilder<Attendence> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Batch).WithMany(x => x.Attendences).HasForeignKey(x => x.BatchId);
            builder.HasOne(x => x.Student).WithMany(x => x.Attendences).HasForeignKey(x => x.StudentId);
        }
    }
}
