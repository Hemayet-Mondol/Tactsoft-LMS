using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tactsoft.Core.Entities;

namespace Tactsoft.Data.EntityConfigurations
{
    public class AttachmentConfiguration:IEntityTypeConfiguration<Attachment>
    {
        public void Configure(EntityTypeBuilder<Attachment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Student).WithMany(x => x.Attachments).HasForeignKey(x => x.StudentId);
            builder.HasOne(x => x.DocumentType).WithMany(x => x.Attachments).HasForeignKey(x => x.DocumentTypeId);
        }
    }
}
