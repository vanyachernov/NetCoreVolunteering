using NetCoreVolunteering.Application.Volunteers;
using NetCoreVolunteering.Application.Volunteers.CreateVolunteer;
using NetCoreVolunteering.Infrastructure;
using NetCoreVolunteering.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    
    builder.Services.AddScoped<PetDbContext>();
    builder.Services.AddScoped<IVolunteersRepository, VolunteersRepository>();
    builder.Services.AddScoped<CreateVolunteerHandler>();
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}
