using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using NetCoreVolunteering.Application.Volunteers;
using NetCoreVolunteering.Domain.Models.Volunteers;
using NetCoreVolunteering.Domain.Models.Volunteers.ValueObjects;
using NetCoreVolunteering.Domain.Shared;

namespace NetCoreVolunteering.Infrastructure.Repositories;

public class VolunteersRepository(PetDbContext dbContext) : IVolunteersRepository
{
    public async Task<Guid> Create(Volunteer volunteer, CancellationToken cancellationToken = default)
    {
        await dbContext.AddAsync(volunteer, cancellationToken);

        await dbContext.SaveChangesAsync(cancellationToken);

        return volunteer.Id;
    }

    public async Task<Result<Volunteer, Error>> GetByPhone(PhoneNumber requestPhone, CancellationToken cancellationToken = default)
    {
        var volunteer = await dbContext.Volunteers
            .Include(v => v.Pets)
            .FirstOrDefaultAsync(p => p.Phone == requestPhone, cancellationToken);

        if (volunteer is null)
        {
            return Errors.General.NotFound();
        }

        return volunteer;
    }
}