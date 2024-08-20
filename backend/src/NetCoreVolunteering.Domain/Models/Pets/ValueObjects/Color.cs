namespace NetCoreVolunteering.Domain.Models.Pets.ValueObjects;

public record Color
{
    private Color() { }

    public string Value { get; } = default!;
};