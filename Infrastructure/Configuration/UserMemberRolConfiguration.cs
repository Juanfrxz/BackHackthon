using Domain.Entities;
using Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class UserMemberRolConfiguration : IEntityTypeConfiguration<UserMemberRoles>
    {
        public void Configure(EntityTypeBuilder<UserMemberRoles> builder)
        {
            builder.ToTable("members_roles");
            
                        
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
            
            builder.HasOne(e => e.UserMember)
                .WithMany(et => et.MemberRols)
                .HasForeignKey(e => e.MemberId);

            builder.HasOne(e => e.Role)
                .WithMany(b => b.MemberRols)
                .HasForeignKey(e => e.RolId);
        }
    }
} 