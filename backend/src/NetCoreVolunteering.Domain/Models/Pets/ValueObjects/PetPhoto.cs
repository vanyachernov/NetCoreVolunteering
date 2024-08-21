using CSharpFunctionalExtensions;

namespace NetCoreVolunteering.Domain.Models.Pets.ValueObjects;

public record PetPhoto
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
        if (string.IsNullOrWhiteSpace(pathToStorage))
        {
            return Result.Failure<PetPhoto>("path cannot be empty");
        }
        
        return new PetPhoto(pathToStorage, isMainPhoto);
    }
}