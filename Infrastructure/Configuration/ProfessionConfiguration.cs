using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class ProfessionConfiguration : IEntityTypeConfiguration<Profession>
    {
        public void Configure(EntityTypeBuilder<Profession> builder)
        {
            builder.ToTable("professions");
            
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.Description)
                .HasColumnName("description")
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
        }
    }
} 