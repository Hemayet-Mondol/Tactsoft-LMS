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
    public class AssignmentDetailsConfiguration:IEntityTypeConfiguration<AssignmentDetails>
    {
        public void Configure(EntityTypeBuilder<AssignmentDetails> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Student).WithMany(x => x.AssignmentDetails).HasForeignKey(x => x.StudentId);
            builder.HasOne(x => x.Assignment).WithMany(x => x.AssignmentDetails).HasForeignKey(x => x.AssignmentId);
        }
    }
}
