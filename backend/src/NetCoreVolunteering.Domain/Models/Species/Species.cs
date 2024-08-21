using NetCoreVolunteering.Domain.Models.Species.IDs;
using NetCoreVolunteering.Domain.Models.Species.Lists;
using NetCoreVolunteering.Domain.Shared;

namespace NetCoreVolunteering.Domain.Models.Species;

public class Species : Entity<SpeciesId>
{
    private Species(SpeciesId id) : base(id) { }
    private Species(SpeciesId speciesId, string name) : base(speciesId) => Name = name;
    
    public string Name { get; }
    public BreedList? Breeds { get; }
}