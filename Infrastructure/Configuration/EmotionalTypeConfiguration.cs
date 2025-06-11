using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class EmotionalTypeConfiguration : IEntityTypeConfiguration<EmotionalType>
    {
        public void Configure(EntityTypeBuilder<EmotionalType> builder)
        {
            builder.ToTable("EmotionalType");
            builder.HasKey(e => e.Id);
        }
    }
} 