using NetCoreVolunteering.Domain.Models.Volunteers;

namespace NetCoreVolunteering.Application.Volunteers;

public interface IVolunteersRepository
{
    Task<Guid> Create(Volunteer volunteer, CancellationToken cancellationToken = default);
}