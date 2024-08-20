namespace NetCoreVolunteering.Domain.Models.Pets.ValueObjects;

public record Description
{
    private Description() { }

    public string Value { get; } = default!;
};