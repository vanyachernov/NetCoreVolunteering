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
    
    public static Result<SocialNetwork> Create(string title, string link)
    {
        if (string.IsNullOrWhiteSpace(title) || title.Length > Constants.MAX_LOW_TEXT_LENGTH)
        {
            return Result.Failure<SocialNetwork>("Title is invalid.");
        }
        
        if (string.IsNullOrWhiteSpace(link))
        {
            return Result.Failure<SocialNetwork>("Link is invalid.");
        }

        return new SocialNetwork(title, link);
    }
}