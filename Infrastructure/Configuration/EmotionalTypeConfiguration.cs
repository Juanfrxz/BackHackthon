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

            builder.HasOne(e => e.EmotionalCategorys)
                .WithMany(ec => ec.EmotionalTypes)
                .HasForeignKey(e => e.EmotionalCategoryId);
        }
    }
} 