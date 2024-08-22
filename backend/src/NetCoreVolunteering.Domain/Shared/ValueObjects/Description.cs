using CSharpFunctionalExtensions;

namespace NetCoreVolunteering.Domain.Shared.ValueObjects;

public record Description
{
    private Description(string value) => Value = value;
    public string Value { get; } = default!;
    
    public static Result<Description> Create(string description)
    {
        if (string.IsNullOrWhiteSpace(description) || description.Length > Constants.MAX_HIGH_TEXT_LENGTH)
        {
            return Result.Failure<Description>("Description is invalid.");
        }

        return new Description(description);
    }
};