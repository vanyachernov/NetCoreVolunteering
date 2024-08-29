using CSharpFunctionalExtensions;

namespace NetCoreVolunteering.Domain.Shared.ValueObjects;

public record Requisite
{
    private Requisite(string title, string description)
    {
        Title = title;
        Description = description;
    }
    
    public string Title { get; } = default!;
    public string Description { get; } = default!;
    
    public static Result<Requisite, Error> Create(string title, string description)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            return Errors.General.ValueIsInvalid("Title");
        }
        
        if (string.IsNullOrWhiteSpace(description))
        {
            return Errors.General.ValueIsInvalid("Description");
        }

        return new Requisite(title, description);
    }
}