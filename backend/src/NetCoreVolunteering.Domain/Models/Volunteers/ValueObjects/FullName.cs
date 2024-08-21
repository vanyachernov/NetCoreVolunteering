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
    public string MiddleName { get; } = default!;
    public string LastName { get; } = default!;
    
    public static Result<FullName> Create(string firstName, string middleName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName) || firstName.Length > Constants.MAX_LOW_TEXT_LENGTH)
        {
            return Result.Failure<FullName>("First Name is invalid.");
        }
        
        if (string.IsNullOrWhiteSpace(middleName) || middleName.Length > Constants.MAX_LOW_TEXT_LENGTH)
        {
            return Result.Failure<FullName>("Middle Name is invalid.");
        }
        
        if (string.IsNullOrWhiteSpace(lastName) || lastName.Length > Constants.MAX_LOW_TEXT_LENGTH)
        {
            return Result.Failure<FullName>("Last Name is invalid.");
        }

        return new FullName(firstName, middleName, lastName);
    }
}