using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class SpecialtieConfiguration : IEntityTypeConfiguration<Specialtie>
    {
        public void Configure(EntityTypeBuilder<Specialtie> builder)
        {
            builder.ToTable("Specialtie");
            builder.HasKey(e => e);
        }
    }
} 