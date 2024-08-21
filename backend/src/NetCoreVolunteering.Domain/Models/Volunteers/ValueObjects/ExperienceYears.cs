using CSharpFunctionalExtensions;

namespace NetCoreVolunteering.Domain.Models.Volunteers.ValueObjects;

public record ExperienceYears
{
    private ExperienceYears(int value) => Value = value;
    
    public int Value { get; } = default!;
    
    public static Result<ExperienceYears> Create(int ages)
    {
        if (ages < 0)
        {
            return Result.Failure<ExperienceYears>("Experience ages is invalid.");
        }

        return new ExperienceYears(ages);
    }
}