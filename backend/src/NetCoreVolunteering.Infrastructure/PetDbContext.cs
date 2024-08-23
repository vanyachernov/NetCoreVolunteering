using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NetCoreVolunteering.Domain.Models.Species;

namespace NetCoreVolunteering.Infrastructure;

public class PetDbContext(IConfiguration configuration) : DbContext
{
    private const string DATABASE = nameof(Database);
    
    public DbSet<Species> Species { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseNpgsql(configuration.GetConnectionString(DATABASE))
            .UseSnakeCaseNamingConvention()
            .UseLoggerFactory(CreateLoggerFactory());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PetDbContext).Assembly);
    }

    private static ILoggerFactory CreateLoggerFactory() => 
        LoggerFactory.Create(builder => builder.AddConsole());
}