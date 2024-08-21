using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;

namespace NetCoreVolunteering.Domain.Models.Volunteers.ValueObjects;

public record PhoneNumber
{
    private const string PhoneRegex = @"^\+380(\d{2}\d{3}\d{4}|\d{2}[ -]?\d{3}[ -]?\d{4})$";
    
    private PhoneNumber(string value) => Value = value;
    public string Value { get; }
    
    public static Result<PhoneNumber> Create(string phone)
    {
        var number = phone.Trim();
        
        if (!Regex.IsMatch(number, PhoneRegex))
        {
            return Result.Failure<PhoneNumber>("Phone is invalid.");
        }

        return new PhoneNumber(number);
    }
};