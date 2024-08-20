namespace NetCoreVolunteering.Domain.Models.Volunteers.ValueObjects;

public record ExperienceYears
{
    private ExperienceYears() { }
    
    public int Value { get; } = default!;
}