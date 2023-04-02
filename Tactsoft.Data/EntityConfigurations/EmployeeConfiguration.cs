using Tactsoft.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tactsoft.Service.EntityConfigurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        void IEntityTypeConfiguration<Employee>.Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasOne(x=>x.Country).WithMany(x => x.Employees).HasForeignKey(e => e.CountryId);
            builder.HasOne(x=>x.State).WithMany(x => x.Employees).HasForeignKey(e => e.StateId);
            builder.HasOne(x=>x.City).WithMany(x => x.Employees).HasForeignKey(e => e.CityId);
            builder.HasOne(x => x.Department).WithMany(x => x.Employees).HasForeignKey(e => e.DepartmentId);
        }
    }
}
