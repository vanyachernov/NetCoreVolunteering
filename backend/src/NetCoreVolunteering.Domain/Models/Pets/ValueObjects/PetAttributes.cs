using CSharpFunctionalExtensions;

namespace NetCoreVolunteering.Domain.Models.Pets.ValueObjects;

public record PetAttributes
{
    private PetAttributes(double weight, double height)
    {
        Weight = weight;
        Height = height;
    }
    
    public double Weight { get; } = default!;
    public double Height { get; } = default!;
    
    public static Result<PetAttributes> Create(double weight, double height)
    {
        if (weight < 0)
        {
            return Result.Failure<PetAttributes>("Weight is invalid.");
        }
        
        if (height < 0)
        {
            return Result.Failure<PetAttributes>("Height is invalid.");
        }

        return new PetAttributes(weight, height);
    }
};