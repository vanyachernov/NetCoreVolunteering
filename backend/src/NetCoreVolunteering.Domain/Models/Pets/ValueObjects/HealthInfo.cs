using CSharpFunctionalExtensions;
using NetCoreVolunteering.Domain.Shared;

namespace NetCoreVolunteering.Domain.Models.Pets.ValueObjects;

public record HealthInfo
{
    private HealthInfo(string value) => Value = value;

    public string Value { get; } = default!;
    
    public static Result<HealthInfo> Create(string healthInfo)
    {
        if (string.IsNullOrWhiteSpace(healthInfo) || healthInfo.Length > Constants.MAX_LOW_TEXT_LENGTH)
        {
            return Result.Failure<HealthInfo>("Health Info is invalid.");
        }

        return new HealthInfo(healthInfo);
    }
};