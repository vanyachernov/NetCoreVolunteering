using NetCoreVolunteering.Domain.Models.Pets.ValueObjects;

namespace NetCoreVolunteering.Domain.Models.Pets.Lists;

public record PetPhotoList
{
    public List<PetPhoto> PetPhotos { get; }
};