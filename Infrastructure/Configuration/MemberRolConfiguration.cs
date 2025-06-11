using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class MemberRolConfiguration : IEntityTypeConfiguration<MemberRol>
    {
        public void Configure(EntityTypeBuilder<MemberRol> builder)
        {
            builder.ToTable("MemberRol");
            builder.HasKey(e => e);
        }
    }
} 