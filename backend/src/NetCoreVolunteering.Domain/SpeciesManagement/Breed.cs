using CSharpFunctionalExtensions;
using NetCoreVolunteering.Domain.Shared;
using NetCoreVolunteering.Domain.Shared.ValueObjects;

namespace NetCoreVolunteering.Domain.SpeciesManagement;

public class Breed : Shared.Entity<BreedId>
{
    private Breed(BreedId id) : base(id) { }
    private Breed(BreedId id, string breeds) : base(id) => Name = breeds;
    
    public string Name { get; private set; } = default!;

    public static Result<Breed> Create(BreedId id, string name)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length > Constants.MAX_HIGH_TEXT_LENGTH)
        {
            return Result.Failure<Breed>("Breeds is invalid");
        }

        return new Breed(id, name);
    }
}