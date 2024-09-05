using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NetCoreVolunteering.API.Extensions;
using NetCoreVolunteering.API.Response;
using NetCoreVolunteering.Application.Volunteers.CreateVolunteer;
using NetCoreVolunteering.Domain.Shared;

namespace NetCoreVolunteering.API.Controllers;

[ApiController]
[Route("[controller]")]
public class VolunteersController : ApplicationController
{ 
    [HttpPost]
    public async Task<ActionResult<Guid>> Create(
        [FromServices] CreateVolunteerHandler handler,
        [FromBody] CreateVolunteerRequest request,
        CancellationToken cancellationToken = default)
    {
        var result = await handler.Handle(request, cancellationToken);
        
        if (result.IsFailure)
        {
            return result.Error.ToResponse();
        }

        return Ok(result.Value);
    }
}