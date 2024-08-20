namespace NetCoreVolunteering.Domain.Models.Volunteers.ValueObjects;

public record Description
{
    private Description() { }

    public string Value { get; } = default!;
};