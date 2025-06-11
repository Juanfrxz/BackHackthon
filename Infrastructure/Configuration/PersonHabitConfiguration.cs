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
        }
    }
} 