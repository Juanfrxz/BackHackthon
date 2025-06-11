using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class ConstituentConfiguration : IEntityTypeConfiguration<Constituent>
    {
        public void Configure(EntityTypeBuilder<Constituent> builder)
        {
            builder.ToTable("Constituent");
            builder.HasKey(e => e);
        }
    }
}