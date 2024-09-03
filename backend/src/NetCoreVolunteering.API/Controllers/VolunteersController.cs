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
        [FromServices] IValidator<CreateVolunteerRequest> validator,
        [FromBody] CreateVolunteerRequest request,
        CancellationToken cancellationToken = default)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            var validationErrors = validationResult.Errors;

            var errors =
                from validationError in validationErrors
                let error = Error.Validation(validationError.ErrorCode, validationError.ErrorMessage)
                select new ResponseError(error.Code, error.Message, validationError.PropertyName);

            var envelope = Envelope.Error(errors);

            return BadRequest(envelope);
        }
        
        var result = await handler.Handle(request, cancellationToken);
        
        if (result.IsFailure)
        {
            return result.Error.ToResponse();
        }

        return Ok(result.Value);
    }
}