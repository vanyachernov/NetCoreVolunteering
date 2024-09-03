using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;
using NetCoreVolunteering.Domain.Shared;

namespace NetCoreVolunteering.Domain.PetManagement.ValueObjects;

public record Email
{
    private const string EmailRegex = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
    
    private Email(string value) => Value = value;
    public string Value { get; } = default!;

    public static Result<Email, Error> Create(string email)
    {
        if (string.IsNullOrWhiteSpace(email) || !Regex.IsMatch(email, EmailRegex))
        {
            return Errors.General.ValueIsInvalid("Email");
        }

        return new Email(email);
    }
}