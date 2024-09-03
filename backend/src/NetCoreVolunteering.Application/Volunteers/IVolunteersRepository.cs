using CSharpFunctionalExtensions;
using NetCoreVolunteering.Domain.PetManagement;
using NetCoreVolunteering.Domain.Shared;
using NetCoreVolunteering.Domain.Shared.ValueObjects;

namespace NetCoreVolunteering.Application.Volunteers;

public interface IVolunteersRepository
{
    Task<Guid> Create(Volunteer volunteer, CancellationToken cancellationToken = default);
    Task<Result<Volunteer, Error>> GetByPhone(PhoneNumber requestPhone, CancellationToken cancellationToken = default);
}