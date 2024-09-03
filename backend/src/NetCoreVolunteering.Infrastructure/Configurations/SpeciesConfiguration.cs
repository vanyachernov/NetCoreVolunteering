using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreVolunteering.Domain.Shared.ValueObjects;
using NetCoreVolunteering.Domain.SpeciesManagement;

namespace NetCoreVolunteering.Infrastructure.Configurations;

public class SpeciesConfiguration : IEntityTypeConfiguration<Species>
{
    public void Configure(EntityTypeBuilder<Species> builder)
    {
        builder.ToTable("species");
        
        builder
            .HasKey(v => v.Id);
        
        builder.Property(p => p.Id)
            .HasConversion(
                id => id.Value,
                value => SpeciesId.Create(value));

        builder
            .Property(s => s.Name)
            .IsRequired();

        builder
            .HasMany(s => s.Breeds)
            .WithOne()
            .HasForeignKey("breed_id");
    }
}