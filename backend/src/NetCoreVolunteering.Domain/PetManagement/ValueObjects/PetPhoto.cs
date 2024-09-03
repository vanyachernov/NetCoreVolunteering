using CSharpFunctionalExtensions;
using NetCoreVolunteering.Domain.Shared;

namespace NetCoreVolunteering.Domain.PetManagement.ValueObjects;

public record PetPhoto
{
    private PetPhoto(string path, bool isMainPhoto)
    {
        Path = path;
        IsMainPhoto = isMainPhoto;
    }
    
    public string Path { get;  }
    public bool IsMainPhoto { get; }

    public static Result<PetPhoto, Error> Create(string pathToStorage, bool isMainPhoto)
    {
        if (string.IsNullOrWhiteSpace(pathToStorage))
        {
            return Errors.General.ValueIsInvalid("PetPhoto");
        }
        
        return new PetPhoto(pathToStorage, isMainPhoto);
    }
}