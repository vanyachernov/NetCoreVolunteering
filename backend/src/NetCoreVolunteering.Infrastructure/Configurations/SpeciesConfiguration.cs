using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreVolunteering.Domain.Models;
using NetCoreVolunteering.Domain.Models.Species;
using NetCoreVolunteering.Domain.Models.Species.IDs;
using NetCoreVolunteering.Domain.Models.Volunteers;
using NetCoreVolunteering.Domain.Models.Volunteers.IDs;
using NetCoreVolunteering.Domain.Shared;

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

        builder.Property(s => s.Name).IsRequired();
        
        builder
            .OwnsOne(s => s.Breeds, sb =>
            {
                sb.ToJson();

                sb
                    .OwnsMany(bb => bb.Breeds, bl =>
                    {
                        bl
                            .Property(b => b.Breeds)
                            .IsRequired();
                    });
            });
    }
}