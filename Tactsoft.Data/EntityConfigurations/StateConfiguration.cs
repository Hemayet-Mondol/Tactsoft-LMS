using Tactsoft.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tactsoft.Service.EntityConfigurations
{
    public class StateConfiguration : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x=>x.Country).WithMany(x => x.States).HasForeignKey(x => x.CountryId);
        }
    }
}
