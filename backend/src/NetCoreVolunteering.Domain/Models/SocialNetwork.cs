namespace NetCoreVolunteering.Domain.Models;

public class SocialNetwork
{
    public Guid Id { get; set; }
    public string Title { get; set; } = default!;
    public string Link { get; set; } = default!;
}