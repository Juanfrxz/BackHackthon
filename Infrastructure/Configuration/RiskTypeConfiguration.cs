using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class RiskTypeConfiguration : IEntityTypeConfiguration<RiskType>
    {
        public void Configure(EntityTypeBuilder<RiskType> builder)
        {
            builder.ToTable("RiskType");
            builder.HasKey(e => e.Id);
        }
    }
} 