using CSharpFunctionalExtensions;

namespace NetCoreVolunteering.Domain.Models.Pets;

public class PetPhoto
{
    private PetPhoto(string pathToStorage, bool isMainPhoto)
    {
        Path = pathToStorage;
        IsMainPhoto = isMainPhoto;
    }
    
    public string Path { get;  }
    public bool IsMainPhoto { get; }

    public static Result<PetPhoto> Create(string pathToStorage, bool isMainPhoto)
    {
        // So far.
        return new PetPhoto(pathToStorage, isMainPhoto);
    }
}