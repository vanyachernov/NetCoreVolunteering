using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;

namespace NetCoreVolunteering.Domain.Shared.ValueObjects;

public record PhoneNumber
{
    private const string PhoneRegex = @"^\+380(\d{2}\d{3}\d{4}|\d{2}[ -]?\d{3}[ -]?\d{4})$";
    
    private PhoneNumber(string value) => Value = value;
    public string Value { get; }
    
    public static Result<PhoneNumber, Error> Create(string phone)
    {
        var number = phone.Trim();
        
        if (!Regex.IsMatch(number, PhoneRegex))
        {
            return Errors.General.ValueIsInvalid("Phone");
        }

        return new PhoneNumber(number);
    }
};