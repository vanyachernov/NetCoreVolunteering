namespace NetCoreVolunteering.Domain.PetManagement.ValueObjects;

public record PetPhotoList
{
    private PetPhotoList() { }

    public PetPhotoList(IEnumerable<PetPhoto> hPhotos)
    {
        PetPhotos = hPhotos.ToList();
    }
    
    public IReadOnlyList<PetPhoto> PetPhotos { get; }
};