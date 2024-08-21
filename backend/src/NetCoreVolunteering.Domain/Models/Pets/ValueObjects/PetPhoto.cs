using CSharpFunctionalExtensions;

namespace NetCoreVolunteering.Domain.Models.Pets.ValueObjects;

public record PetPhoto
{
    private PetPhoto(string path, bool isMainPhoto)
    {
        Path = path;
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