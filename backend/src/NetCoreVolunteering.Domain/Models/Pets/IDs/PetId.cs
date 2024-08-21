namespace NetCoreVolunteering.Domain.Models.Pets.IDs;

public class PetId
{
    private PetId(Guid value)
    {
        Value = value;
    }
    
    public Guid Value { get; }

    public static PetId NewPetId() => new(Guid.NewGuid());

    public static PetId Empty() => new(Guid.Empty);
    
    public static PetId Create(Guid id) => new(id);
}