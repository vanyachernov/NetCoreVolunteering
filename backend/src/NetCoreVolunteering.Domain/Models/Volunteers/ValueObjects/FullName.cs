namespace NetCoreVolunteering.Domain.Models.Volunteers.ValueObjects;

public record FullName
{
    private FullName() { }
    
    public string FirstName { get; } = default!;
    public string MiddleName { get; } = default!;
    public string LastName { get; } = default!;
}