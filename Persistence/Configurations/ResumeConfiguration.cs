using Application.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RecruiterSystem.Persistence.Configurations
{
    public class ChallengeConfiguration : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Challenge>
    {
        public void Configure(EntityTypeBuilder<Resume> builder)
        {
        }
    }
}