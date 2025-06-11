using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class PhonePersonConfiguration : IEntityTypeConfiguration<PhonePerson>
    {
        public void Configure(EntityTypeBuilder<PhonePerson> builder)
        {
            builder.ToTable("PhonePerson");
            builder.HasKey(e => e.Id);
        }
    }
} 