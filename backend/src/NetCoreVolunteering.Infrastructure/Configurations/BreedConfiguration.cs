using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreVolunteering.Domain.Shared.ValueObjects;
using NetCoreVolunteering.Domain.SpeciesManagement;

namespace NetCoreVolunteering.Infrastructure.Configurations;

public class BreedConfiguration : IEntityTypeConfiguration<Breed>
{
    public void Configure(EntityTypeBuilder<Breed> builder)
    {
        builder
            .ToTable("breeds");
        
        builder
            .HasKey(b => b.Id);

        builder
            .Property(b => b.Id)
            .HasConversion(
                id => id.Value,
                value => BreedId.Create(value)
            );

        builder
            .Property(b => b.Name)
            .IsRequired();
    }
}