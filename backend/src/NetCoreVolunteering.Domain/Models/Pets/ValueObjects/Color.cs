using CSharpFunctionalExtensions;
using NetCoreVolunteering.Domain.Shared;

namespace NetCoreVolunteering.Domain.Models.Pets.ValueObjects;

public record Color
{
    private Color(string value) => Value = value;

    public string Value { get; } = default!;
    
    public static Result<Color> Create(string color)
    {
        if (string.IsNullOrWhiteSpace(color) || color.Length > Constants.MAX_LOW_TEXT_LENGTH)
        {
            return Result.Failure<Color>("Health Info is invalid.");
        }

        return new Color(color);
    }
};