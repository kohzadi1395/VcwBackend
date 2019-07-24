using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class ChallengeConfiguration : IEntityTypeConfiguration<Challenge>
    {
        public void Configure(EntityTypeBuilder<Challenge> builder)
        {
            
        }
    }
    public class AttachmentConfiguration : IEntityTypeConfiguration<Attachment>
    {
        public void Configure(EntityTypeBuilder<Attachment> builder)
        {
            builder.HasOne(attachment => attachment.Challenge)
                .WithMany(c => c.Attachments)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
    public class FilterConfiguration : IEntityTypeConfiguration<Filter>
    {
        public void Configure(EntityTypeBuilder<Filter> builder)
        {
            
        }
    }
}