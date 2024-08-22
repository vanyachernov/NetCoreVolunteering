using CSharpFunctionalExtensions;
using NetCoreVolunteering.Domain.Models.Species.IDs;
using NetCoreVolunteering.Domain.Shared;

namespace NetCoreVolunteering.Domain.Models.Species;

public class Species : Shared.Entity<SpeciesId>
{
    private readonly List<Breed> _breeds = [];
    
    private Species(SpeciesId id) : base(id) { }
    private Species(SpeciesId speciesId, string name) : base(speciesId) => Name = name;
    
    public string Name { get; private set; }
    public IReadOnlyCollection<Breed>? Breeds => _breeds;

    public static Result<Species> Create(SpeciesId id, string name)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length > Constants.MAX_LOW_TEXT_LENGTH)
        {
            return Result.Failure<Species>("Species name is invalid.");
        }

        return new Species(id, name);
    }
}