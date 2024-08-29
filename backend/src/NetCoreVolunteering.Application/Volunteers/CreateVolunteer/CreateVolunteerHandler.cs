using CSharpFunctionalExtensions;
using NetCoreVolunteering.Domain.Models.Volunteers;
using NetCoreVolunteering.Domain.Models.Volunteers.IDs;
using NetCoreVolunteering.Domain.Models.Volunteers.ValueObjects;
using NetCoreVolunteering.Domain.Shared;
using NetCoreVolunteering.Domain.Shared.ValueObjects;

namespace NetCoreVolunteering.Application.Volunteers.CreateVolunteer;

public class CreateVolunteerHandler(IVolunteersRepository volunteersRepository)
{
    public async Task<Result<Guid, Error>> Handle(
        CreateVolunteerRequest request,
        CancellationToken cancellationToken = default)
    {
        var volunteerFullName = FullName.Create(request.FirstName, request.MiddleName, request.LastName);
        if (volunteerFullName.IsFailure)
        {
            return volunteerFullName.Error;
        }
        
        var volunteerEmail = Email.Create(request.Email);
        if (volunteerEmail.IsFailure)
        {
            return volunteerEmail.Error;
        }
        
        var volunteerDescription = Description.Create(request.Description);
        if (volunteerDescription.IsFailure)
        {
            return volunteerDescription.Error;
        }
        
        var volunteerExperienceYears = ExperienceYears.Create(request.ExperienceYears);
        if (volunteerExperienceYears.IsFailure)
        {
            return volunteerExperienceYears.Error;
        }
        
        var volunteerPhone = PhoneNumber.Create(request.Phone);
        if (volunteerPhone.IsFailure)
        {
            return volunteerPhone.Error;
        }

        var existingVolunteer = await volunteersRepository.GetByPhone(volunteerPhone.Value);

        if (existingVolunteer.IsSuccess)
        {
            return Errors.Volunteer.AlreadyExists();
        }
        
        var voluteerId = VolunteerId.NewId();
        
        var volunteerToCreate = Volunteer.Create(voluteerId, volunteerFullName.Value, volunteerEmail.Value, volunteerDescription.Value, volunteerExperienceYears.Value, volunteerPhone.Value);
        
        if (volunteerToCreate.IsFailure)
        {
            return volunteerToCreate.Error;
        }
        
        await volunteersRepository.Create(volunteerToCreate.Value, cancellationToken);

        return (Guid)volunteerToCreate.Value.Id;
    }
}