namespace NetCoreVolunteering.Domain.PetManagement.ValueObjects;

public record SocialNetworksList
{
    private SocialNetworksList() { }

    public SocialNetworksList(IEnumerable<SocialNetwork> socialNetworks)
    {
        Socials = socialNetworks.ToList();
    }
    
    public IReadOnlyList<SocialNetwork> Socials { get; }
};