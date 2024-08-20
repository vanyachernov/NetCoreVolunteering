namespace NetCoreVolunteering.Domain.Models.Pets.IDs;

public class PetPhotoId
{
    private PetPhotoId(Guid value)
    {
        Value = value;
    }
    
    public Guid Value { get; }

    public static PetPhotoId NewPetId() => new(Guid.NewGuid());

    public static PetPhotoId Empty() => new(Guid.Empty);
    
    public static PetPhotoId Create(Guid id) => new(id);
}