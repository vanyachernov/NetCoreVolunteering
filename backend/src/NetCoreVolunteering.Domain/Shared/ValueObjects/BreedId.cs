namespace NetCoreVolunteering.Domain.Shared.ValueObjects;

public record BreedId
{
    private BreedId(Guid value) => Value = value;
    
    public Guid Value { get; }

    public static BreedId NewBreedId() => new(Guid.NewGuid());

    public static BreedId Empty() => new(Guid.Empty);
    
    public static BreedId Create(Guid id) => new(id);
}