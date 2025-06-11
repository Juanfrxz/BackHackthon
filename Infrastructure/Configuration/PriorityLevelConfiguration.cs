using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class PriorityLevelConfiguration : IEntityTypeConfiguration<PriorityLevel>
    {
        public void Configure(EntityTypeBuilder<PriorityLevel> builder)
        {
            builder.ToTable("PriorityLevel");
            builder.HasKey(e => e.Id);
        }
    }
} 