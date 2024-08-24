namespace NetCoreVolunteering.Domain.Models.Volunteers.IDs;

public record VolunteerId
{
    public Guid Value { get; }

    private VolunteerId(Guid id) => Value = id;

    public static VolunteerId NewId() => new VolunteerId(Guid.NewGuid());
    public static VolunteerId Empty() => new VolunteerId(Guid.Empty);
    public static VolunteerId Create(Guid id) => new VolunteerId(id);

    public static implicit operator Guid(VolunteerId volunteerId)
    {
        ArgumentNullException.ThrowIfNull(volunteerId);
        return volunteerId.Value;
    }
}