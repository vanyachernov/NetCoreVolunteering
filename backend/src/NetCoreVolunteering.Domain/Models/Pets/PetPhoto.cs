using CSharpFunctionalExtensions;
using NetCoreVolunteering.Domain.Models.Pets.IDs;

namespace NetCoreVolunteering.Domain.Models;

public class PetPhoto : Shared.Entity<PetPhotoId>
{
    // For EF Core
    private PetPhoto(PetPhotoId petPhotoId) : base(petPhotoId) {}
    
    private PetPhoto(PetPhotoId petPhotoId, string pathToStorage, bool isMainPhoto) : base(petPhotoId)
    {
        Path = pathToStorage;
        IsMainPhoto = isMainPhoto;
    }
    
    public string Path { get; private set; }
    public bool IsMainPhoto { get; private set; }

    public static Result<PetPhoto> Create(PetPhotoId petPhotoId, string pathToStorage, bool isMainPhoto)
    {
        // So far.
        return new PetPhoto(petPhotoId, pathToStorage, isMainPhoto);
    }
}