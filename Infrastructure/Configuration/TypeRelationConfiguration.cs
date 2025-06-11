using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;  

namespace Infrastructure.Configuration
{
    public class TypeRelationConfiguration : IEntityTypeConfiguration<TypeRelation>
    {
        public void Configure(EntityTypeBuilder<TypeRelation> builder)
        {
            builder.ToTable("TypeRelation");
            builder.HasKey(e => e.Id);
        }
    }
} 