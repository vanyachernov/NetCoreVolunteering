using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;

namespace NetCoreVolunteering.Domain.Models.Volunteers.ValueObjects;

public record Email
{
    private const string EmailRegex = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
    
    private Email(string value) => Value = value;
    public string Value { get; } = default!;

    public static Result<Email> Create(string email)
    {
        if (string.IsNullOrWhiteSpace(email) || !Regex.IsMatch(email, EmailRegex))
        {
            return Result.Failure<Email>("Email is invalid.");
        }

        return new Email(email);
    }
}