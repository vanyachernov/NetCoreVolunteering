namespace NetCoreVolunteering.Domain.Models.Volunteers.ValueObjects;

public record Email
{
    private Email() { }
    
    public string Value { get; } = default!;
}