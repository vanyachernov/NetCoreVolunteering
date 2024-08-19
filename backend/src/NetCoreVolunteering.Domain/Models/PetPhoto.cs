using CSharpFunctionalExtensions;

namespace NetCoreVolunteering.Domain.Models;

public class PetPhoto
{
    // For EF Core
    private PetPhoto() {}
    
    private PetPhoto(Guid petPhotoId, string pathToStorage, bool isMainPhoto)
    {
        Path = pathToStorage;
        IsMainPhoto = isMainPhoto;
    }
    
    public string Path { get; }
    public bool IsMainPhoto { get; set; }

    public static Result<PetPhoto> Create(Guid petPhotoId, string pathToStorage, bool isMainPhoto)
    {
        // So far.
        return new PetPhoto(petPhotoId, pathToStorage, isMainPhoto);
    }
}