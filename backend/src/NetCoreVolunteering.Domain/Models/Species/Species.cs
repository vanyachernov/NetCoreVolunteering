using NetCoreVolunteering.Domain.Models.Species.IDs;
using NetCoreVolunteering.Domain.Shared;

namespace NetCoreVolunteering.Domain.Models.Species;

public class Species : Entity<SpeciesId>
{
    private Species(SpeciesId id) : base(id) { }
    
    public string Name { get; }

    private Species(SpeciesId speciesId, string name) : base(speciesId)
    {
        Name = name;
    }
}