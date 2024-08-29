using CSharpFunctionalExtensions;
using NetCoreVolunteering.Domain.Shared;

namespace NetCoreVolunteering.Domain.Models.Volunteers.ValueObjects;

public record ExperienceYears
{
    private ExperienceYears(int value) => Value = value;
    
    public int Value { get; } = default!;
    
    public static Result<ExperienceYears, Error> Create(int ages)
    {
        if (ages < 0)
        {
            return Errors.General.ValueIsInvalid("Ages");
        }

        return new ExperienceYears(ages);
    }
}