using Domain.Entities;
using Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class UserMemberRoleConfiguration : IEntityTypeConfiguration<UserMemberRole>
    {
        public void Configure(EntityTypeBuilder<UserMemberRole> builder)
        {
            builder.ToTable("usermembers_roles");
            
                        
            builder.HasKey(x => new { x.UserMemberId, x.RoleId });

            builder.Property(x => x.UserMemberId)
                .HasColumnName("UserMemberId");
            
            builder.Property(x => x.RoleId)
                .HasColumnName("roleId");

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
            
            builder.HasOne(e => e.UserMembers)
                .WithMany(et => et.UserMemberRoles)
                .HasForeignKey(e => e.UserMemberId);

            builder.HasOne(e => e.Role)
                .WithMany(b => b.UserMemberRoles)
                .HasForeignKey(e => e.RoleId);
        }
    }
} 