using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class ConstituentConfiguration : IEntityTypeConfiguration<Constituent>
    {
        public void Configure(EntityTypeBuilder<Constituent> builder)
        {
            builder.ToTable("constituents");
            
            builder.HasKey(x => new { x.SupportnetworkId, x.TypeRelationId, x.PriorityLevelId });

            builder.Property(x => x.SupportnetworkId)
                .HasColumnName("supportnetworkId");
            
            builder.Property(x => x.TypeRelationId)
                .HasColumnName("typeRelationId");

            builder.Property(x => x.MemberName)
                .HasColumnName("memberName")
                .HasMaxLength(50);

            builder.Property(x => x.Email)
                .HasColumnName("email")
                .HasMaxLength(80);

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
            
            builder.HasOne(e => e.Supportnetwork)
                .WithMany(et => et.Constituents)
                .HasForeignKey(e => e.SupportnetworkId);

            builder.HasOne(e => e.TypeRelation)
                .WithMany(b => b.Constituents)
                .HasForeignKey(e => e.TypeRelationId);
        }
    }
}