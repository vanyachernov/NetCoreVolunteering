using CSharpFunctionalExtensions;
using NetCoreVolunteering.Domain.Shared;

namespace NetCoreVolunteering.Domain.Models.Volunteers.ValueObjects;

public record FullName
{
    private FullName(string firstName, string middleName, string lastName)
    {
        FirstName = firstName;
        MiddleName = middleName;
        LastName = lastName;
    }
    
    public string FirstName { get; } = default!;
    public string? MiddleName { get; } = default!;
    public string LastName { get; } = default!;
    
    public static Result<FullName, Error> Create(string firstName, string? middleName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName) || firstName.Length > Constants.MAX_LOW_TEXT_LENGTH)
        {
            return Errors.General.ValueIsInvalid("FirstName");
        }
        
        if (string.IsNullOrWhiteSpace(middleName) || middleName.Length > Constants.MAX_LOW_TEXT_LENGTH)
        {
            return Errors.General.ValueIsInvalid("MiddleName");
        }
        
        if (string.IsNullOrWhiteSpace(lastName) || lastName.Length > Constants.MAX_LOW_TEXT_LENGTH)
        {
            return Errors.General.ValueIsInvalid("LastName");
        }

        return new FullName(firstName, middleName, lastName);
    }
}