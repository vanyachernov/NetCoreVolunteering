namespace NetCoreVolunteering.Domain.Models.Pets.ValueObjects;

public record PhoneNumber
{
    private const string PhoneRegex = @"^\+380(\d{2}\d{3}\d{4}|\d{2}[ -]?\d{3}[ -]?\d{4})$";
    
    private PhoneNumber(string number) => Value = number;
    public string Value { get; }
};