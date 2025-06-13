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
            
                        
            builder.HasKey(x => new { x.MemberId, x.RolId });

            builder.Property(x => x.MemberId)
                .HasColumnName("memberId");
            
            builder.Property(x => x.RolId)
                .HasColumnName("rolId");

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
            
            builder.HasOne(e => e.Member)
                .WithMany(et => et.MemberRols)
                .HasForeignKey(e => e.MemberId);

            builder.HasOne(e => e.Rol)
                .WithMany(b => b.MemberRols)
                .HasForeignKey(e => e.RolId);
        }
    }
} 