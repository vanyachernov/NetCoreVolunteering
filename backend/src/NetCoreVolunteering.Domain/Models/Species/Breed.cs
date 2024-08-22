using CSharpFunctionalExtensions;
using NetCoreVolunteering.Domain.Models.Species.IDs;
using NetCoreVolunteering.Domain.Shared;

namespace NetCoreVolunteering.Domain.Models.Species;

public class Breed
{
    private Breed() { }
    private Breed(string breeds) => Breeds = breeds;
    
    public string Breeds { get; private set;  } = default!;

    public static Result<Breed> Create(string breeds)
    {
        if (string.IsNullOrWhiteSpace(breeds) || breeds.Length > Constants.MAX_HIGH_TEXT_LENGTH)
        {
            return Result.Failure<Breed>("Breeds is invalid");
        }

        return new Breed(breeds);
    }
}