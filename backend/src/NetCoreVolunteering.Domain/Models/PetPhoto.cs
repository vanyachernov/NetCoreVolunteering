namespace NetCoreVolunteering.Domain.Models;

public class PetPhoto
{
    public Guid Id { get; set; }
    public string Path { get; set; } = default!;
    public bool IsMainPhoto { get; set; }
}