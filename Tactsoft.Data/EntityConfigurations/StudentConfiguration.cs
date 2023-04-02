using Tactsoft.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
    
namespace Tactsoft.Service.EntityConfigurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x=>x.Country).WithMany(x=>x.Students).HasForeignKey(x=>x.CountryId);
            builder.HasOne(x=>x.State).WithMany(x=>x.Students).HasForeignKey(x=>x.StateId);
            builder.HasOne(x=>x.City).WithMany(x=>x.Students).HasForeignKey(x=>x.CityId);
            builder.HasOne(x => x.Batch).WithMany(x => x.Students).HasForeignKey(x => x.BatchId);
            builder.HasOne(x => x.Course).WithMany(x => x.Students).HasForeignKey(x => x.CourseId);
        }
    }
}
