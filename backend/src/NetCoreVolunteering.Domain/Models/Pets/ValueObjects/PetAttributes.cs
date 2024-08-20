namespace NetCoreVolunteering.Domain.Models.Pets.ValueObjects;

public record PetAttributes
{
    private PetAttributes() { }
    
    public double Weight { get; } = default!;
    public double Height { get; } = default!;
};