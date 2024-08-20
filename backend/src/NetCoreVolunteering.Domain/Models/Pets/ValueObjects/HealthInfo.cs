namespace NetCoreVolunteering.Domain.Models.Pets.ValueObjects;

public record HealthInfo
{
    private HealthInfo() { }

    public string Value { get; } = default!;
};