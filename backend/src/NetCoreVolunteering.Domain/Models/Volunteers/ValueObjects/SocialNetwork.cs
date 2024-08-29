using CSharpFunctionalExtensions;
using NetCoreVolunteering.Domain.Shared;

namespace NetCoreVolunteering.Domain.Models.Volunteers;

public record SocialNetwork
{
    private SocialNetwork(string title, string link)
    {
        Title = title;
        Link = link;
    }
    
    public string Title { get; } = default!;
    public string Link { get; } = default!;
    
    public static Result<SocialNetwork, Error> Create(string title, string link)
    {
        if (string.IsNullOrWhiteSpace(title) || title.Length > Constants.MAX_LOW_TEXT_LENGTH)
        {
            return Errors.General.ValueIsInvalid("Title");
        }
        
        if (string.IsNullOrWhiteSpace(link))
        {
            return Errors.General.ValueIsInvalid("Link");
        }

        return new SocialNetwork(title, link);
    }
}