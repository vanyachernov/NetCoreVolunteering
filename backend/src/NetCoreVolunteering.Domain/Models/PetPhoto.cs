using CSharpFunctionalExtensions;

namespace NetCoreVolunteering.Domain.Models;

public class PetPhoto
{
    // For EF Core
    private PetPhoto() {}
    
    private PetPhoto(Guid petPhotoId, string pathToStorage, bool isMainPhoto)
    {
        Id = petPhotoId;
        Path = pathToStorage;
        IsMainPhoto = isMainPhoto;
    }
    
    public Guid Id { get; private set; }
    public string Path { get; private set; }
    public bool IsMainPhoto { get; private set; }

    public static Result<PetPhoto> Create(Guid petPhotoId, string pathToStorage, bool isMainPhoto)
    {
        // So far.
        return new PetPhoto(petPhotoId, pathToStorage, isMainPhoto);
    }
}