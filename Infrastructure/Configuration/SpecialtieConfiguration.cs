using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class SpecialtieConfiguration : IEntityTypeConfiguration<Specialtie>
    {
        public void Configure(EntityTypeBuilder<Specialtie> builder)
        {
            builder.ToTable("specialties");
            
            builder.HasKey(x => new { x.ProfessionalId, x.SpecialtyId });

            builder.Property(x => x.ProfessionalId)
                .HasColumnName("professionalId");
            
            builder.Property(x => x.SpecialtyId)
                .HasColumnName("specialtyId");

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
            
            builder.HasOne(e => e.Professional)
                .WithMany(et => et.Specialties)
                .HasForeignKey(e => e.ProfessionalId);

            builder.HasOne(e => e.Specialty)
                .WithMany(b => b.Specialties)
                .HasForeignKey(e => e.SpecialtyId);
        }
    }
} 