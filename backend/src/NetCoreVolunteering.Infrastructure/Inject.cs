using Microsoft.Extensions.DependencyInjection;
using NetCoreVolunteering.Application.Volunteers;
using NetCoreVolunteering.Infrastructure.Repositories;

namespace NetCoreVolunteering.Infrastructure;

public static class Inject
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<PetDbContext>();
        
        services.AddScoped<IVolunteersRepository, VolunteersRepository>();
        
        return services;
    }
}