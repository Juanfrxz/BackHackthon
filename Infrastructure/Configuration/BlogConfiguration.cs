using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;
public class BlogConfiguration : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder.ToTable("Blog");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .HasColumnName("id");

        builder.Property(e => e.Summary)
            .HasColumnName("summary")
            .HasColumnType("text");

        builder.Property(e => e.LogDate)
            .HasColumnName("logDate")
            .HasColumnType("timestamp")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();
        
        builder.Property(e => e.Transcription)
            .HasColumnName("transcription")
            .HasColumnType("text");

        builder.Property(e => e.PerceptionAnalysis)
            .HasColumnName("perceptionAnalysis")
            .HasColumnType("text");

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

        builder.HasOne(e => e.PersonProfile)
            .WithMany(p => p.Blogs)
            .HasForeignKey(e => e.PersonProfileId);

        builder.HasOne(e => e.RiskType)
            .WithMany(r => r.Blogs)
            .HasForeignKey(e => e.RiskTypeId);
        
        builder.HasMany(e => e.EmotionalBlogs)
            .WithOne(eb => eb.Blogs)
            .HasForeignKey(eb => eb.BlogId);
    }
}