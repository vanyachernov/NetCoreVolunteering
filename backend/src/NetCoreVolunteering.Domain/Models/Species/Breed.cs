using NetCoreVolunteering.Domain.Models.Species.IDs;
using NetCoreVolunteering.Domain.Shared;

namespace NetCoreVolunteering.Domain.Models.Species;

public class Breed : Entity<BreedId>
{
    private Breed(BreedId breedId) : base(breedId) { }
    
    public string Name { get; set; } = default!;
}