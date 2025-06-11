using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class EmotionalBlogConfiguration : IEntityTypeConfiguration<EmotionalBlog>
    {
        public void Configure(EntityTypeBuilder<EmotionalBlog> builder)
        {
            builder.ToTable("EmotionalBlog");
            builder.HasKey(e => e.Id);
        }
    }
} 