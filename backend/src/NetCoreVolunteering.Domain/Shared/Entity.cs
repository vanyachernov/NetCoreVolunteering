namespace NetCoreVolunteering.Domain.Shared;

public class Entity<TId> 
    where TId : notnull
{
    protected Entity(TId id)
    {
        Id = id;
    }
    
    public TId Id { get; }
}