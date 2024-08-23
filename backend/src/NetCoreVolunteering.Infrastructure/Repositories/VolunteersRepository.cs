using NetCoreVolunteering.Application.Volunteers;
using NetCoreVolunteering.Domain.Models.Volunteers;

namespace NetCoreVolunteering.Infrastructure.Repositories;

public class VolunteersRepository(PetDbContext dbContext) : IVolunteersRepository
{
    public async Task<Guid> Create(Volunteer volunteer, CancellationToken cancellationToken = default)
    {
        await dbContext.AddAsync(volunteer, cancellationToken);

        await dbContext.SaveChangesAsync(cancellationToken);

        return volunteer.Id;
    }
}