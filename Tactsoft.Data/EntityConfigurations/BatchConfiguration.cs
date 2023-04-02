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
    public class BatchConfiguration : IEntityTypeConfiguration<Batch>
    {
        public void Configure(EntityTypeBuilder<Batch> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x=>x.Course).WithMany(x=>x.Batchs).HasForeignKey(x=>x.CourseId);
            builder.HasOne(x => x.ClassRoom).WithMany(x => x.Batchs).HasForeignKey(x => x.ClassRoomId);
            builder.HasOne(x => x.Trainer).WithMany(x => x.Batchs).HasForeignKey(x => x.TrainerId);
            builder.HasOne(x => x.Venue).WithMany(x => x.Batchs).HasForeignKey(x => x.VenueId);
        }
    }
}
