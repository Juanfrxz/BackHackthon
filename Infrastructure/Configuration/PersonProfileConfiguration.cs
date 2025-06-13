using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;
public class PersonProfileConfiguration : IEntityTypeConfiguration<PersonProfile>
{
    public void Configure(EntityTypeBuilder<PersonProfile> builder)
    {
        builder.ToTable("persons_profiles");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .HasColumnName("id");

        builder.Property(e => e.Name)
            .HasColumnName("name")
            .HasMaxLength(50);

        builder.Property(e => e.LastName)
            .HasColumnName("lastName")
            .HasMaxLength(50);

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

        builder.HasOne(e => e.City)
            .WithMany(c => c.PersonProfiles)
            .HasForeignKey(e => e.CityId);
        
        builder.HasOne(e => e.PersonType)
            .WithMany(pt => pt.PersonProfiles)
            .HasForeignKey(e => e.PersonTypeId);

        builder.HasOne(e => e.UserMember)
            .WithMany(m => m.PersonProfiles)
            .HasForeignKey(e => e.MemberId);
    }
}