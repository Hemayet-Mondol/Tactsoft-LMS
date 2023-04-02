using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tactsoft.Core.Entities;

namespace Tactsoft.Data.EntityConfigurations
{
    public class JobplacementConfiguration:IEntityTypeConfiguration<Jobplacement>
    {
        public void Configure(EntityTypeBuilder<Jobplacement> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Department).WithMany(x => x.Jobplacements).HasForeignKey(x => x.DepartmentId);
            builder.HasOne(x => x.Organization).WithMany(x => x.Jobplacements).HasForeignKey(x => x.OrganizationId);
            builder.HasOne(x => x.Student).WithMany(x => x.Jobplacements).HasForeignKey(x => x.StudentId);
        }
    }
}
