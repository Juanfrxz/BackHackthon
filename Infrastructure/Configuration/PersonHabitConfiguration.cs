using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class PersonHabitConfiguration : IEntityTypeConfiguration<PersonHabit>
    {
        public void Configure(EntityTypeBuilder<PersonHabit> builder)
        {
            builder.ToTable("PersonHabit");
            
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .HasColumnName("id");
            
            builder.Property(e => e.RegistrationDate)
            .HasColumnName("registrationDate")
            .HasColumnType("timestamp")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

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

            builder.HasOne(e => e.Habit)
                .WithMany(ec => ec.PersonHabits)
                .HasForeignKey(e => e.HabitId);

            builder.HasOne(e => e.PersonProfile)
            .WithMany(ec => ec.PersonHabits)
            .HasForeignKey(e => e.PersonProfileId);
        }
    }
} 