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
            builder.Property(e => e.Id)
                .HasColumnName("id");
            
            builder.Property(e => e.PhoneNumber)
                .HasColumnName("phoneNumber")
                .HasMaxLength(20);

            builder.Property(e => e.CreatedAt)
                .HasColumnName("createdAt")
                .HasColumnType("timestamp")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updatedAt")
                .HasColumnType("timestamp")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAddOrUpdate();

            builder.HasOne(e => e.ContactType)
                .WithMany(ec => ec.PhonePersons)
                .HasForeignKey(e => e.ContactTypeId);

            builder.HasOne(e => e.PersonProfile)
            .WithMany(ec => ec.PhonePersons)
            .HasForeignKey(e => e.PersonProfileId);
        }
    }
} 