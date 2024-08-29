using CSharpFunctionalExtensions;
using NetCoreVolunteering.Domain.Shared;

namespace NetCoreVolunteering.Domain.Models.Pets.ValueObjects;

public record HealthInfo
{
    private HealthInfo(string value) => Value = value;

    public string Value { get; } = default!;
    
    public static Result<HealthInfo, Error> Create(string healthInfo)
    {
        if (string.IsNullOrWhiteSpace(healthInfo) || healthInfo.Length > Constants.MAX_LOW_TEXT_LENGTH)
        {
            return Errors.General.ValueIsInvalid("HealthInfo");
        }

        return new HealthInfo(healthInfo);
    }
};