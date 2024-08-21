namespace NetCoreVolunteering.Domain.Models.Volunteers.IDs;

public record VolunteerId
{
    public Guid Id { get; }

    private VolunteerId(Guid id) => Id = id;

    public static VolunteerId NewId() => new VolunteerId(Guid.NewGuid());
    public static VolunteerId Empty() => new VolunteerId(Guid.Empty);
    public static VolunteerId Create(Guid id) => new VolunteerId(id);
}