using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class EmotionalBlogConfiguration : IEntityTypeConfiguration<EmotionalBlog>
    {
        public void Configure(EntityTypeBuilder<EmotionalBlog> builder)
        {
            builder.ToTable("emotionals_blogs");
            
            builder.HasKey(x => new { x.EmotionalTypeId, x.BlogId });

            builder.Property(x => x.EmotionalTypeId)
                .HasColumnName("emotionalTypeId");
            
            builder.Property(x => x.BlogId)
                .HasColumnName("blogId");

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
            
            builder.HasOne(e => e.EmotionalTypes)
                .WithMany(et => et.EmotionalBlogs)
                .HasForeignKey(e => e.EmotionalTypeId);

            builder.HasOne(e => e.Blogs)
                .WithMany(b => b.EmotionalBlogs)
                .HasForeignKey(e => e.BlogId);
        }
    }
} 