using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class SupportNetworkConfiguration : IEntityTypeConfiguration<SupportNetwork>
    {
        public void Configure(EntityTypeBuilder<SupportNetwork> builder)
        {
            builder.ToTable("SupportNetwork");
            builder.HasKey(e => e.Id);
        }
    }
} 