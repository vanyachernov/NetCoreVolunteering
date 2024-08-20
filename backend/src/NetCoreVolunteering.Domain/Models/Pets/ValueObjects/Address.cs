namespace NetCoreVolunteering.Domain.Models.Pets.ValueObjects;

public record Address
{
    private Address() { }

    public string Street { get; } = default!;
    public string City { get; } = default!;
    public string State { get; } = default!;
    public string ZipCode { get; } = default!;
};