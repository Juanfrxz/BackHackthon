using Domain.Entities;
using Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;  

namespace Infrastructure.Configuration
{
    public class UserMemberConfiguration : IEntityTypeConfiguration<UserMember>
    {
        public void Configure(EntityTypeBuilder<UserMember> builder)
        {
            builder.ToTable("usermembers");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.Username)
                .HasColumnName("username")
                .HasMaxLength(50);

            builder.Property(e => e.Email)
                .HasColumnName("email")
                .HasMaxLength(80);

            builder.Property(e => e.Password)
                .HasColumnName("password")
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
                
            builder
                    .HasMany(p => p.Roles)
                    .WithMany(p => p.UsersMembers)
                    .UsingEntity<UserMemberRole>(
                        j => j
                            .HasOne(pt => pt.Role)
                            .WithMany(t => t.UserMemberRoles)
                            .HasForeignKey(pt => pt.RoleId),
                        j => j
                            .HasOne(pt => pt.UserMembers)
                            .WithMany(p => p.UserMemberRoles)
                            .HasForeignKey(pt => pt.UserMemberId),
                        j =>
                        {
                            j.HasKey(t => new { t.RoleId, t.UserMemberId });
                            j.ToTable("usermembers_roles");
                        });
        }
    }
} 