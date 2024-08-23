using CSharpFunctionalExtensions;
using NetCoreVolunteering.Domain.Models.Volunteers;
using NetCoreVolunteering.Domain.Models.Volunteers.IDs;
using NetCoreVolunteering.Domain.Models.Volunteers.ValueObjects;
using NetCoreVolunteering.Domain.Shared.ValueObjects;

namespace NetCoreVolunteering.Application.Volunteers.CreateVolunteer;

public class CreateVolunteerHandler(IVolunteersRepository volunteersRepository)
{
    public async Task<Result<Guid, string>> Handle(
        CreateVolunteerRequest request,
        CancellationToken cancellationToken = default)
    {
        var voluteerId = VolunteerId.NewId();

        var volunteerFullName = FullName.Create(request.firstName, request.middleName, request.lastName);
        if (volunteerFullName.IsFailure)
        {
            return volunteerFullName.Error;
        }

        var volunteerEmail = Email.Create(request.email);
        if (volunteerEmail.IsFailure)
        {
            return volunteerEmail.Error;
        }
        
        var volunteerDescription = Description.Create(request.description);
        if (volunteerDescription.IsFailure)
        {
            return volunteerDescription.Error;
        }
        
        var volunteerExperienceYears = ExperienceYears.Create(request.experienceYears);
        if (volunteerExperienceYears.IsFailure)
        {
            return volunteerExperienceYears.Error;
        }
        
        var volunteerPhone = PhoneNumber.Create(request.phone);
        if (volunteerPhone.IsFailure)
        {
            return volunteerPhone.Error;
        }

        var volunteer = new Volunteer(voluteerId, volunteerFullName.Value, volunteerEmail.Value, volunteerDescription.Value, volunteerExperienceYears.Value, volunteerPhone.Value);

        await volunteersRepository.Create(volunteer, cancellationToken);

        return (Guid)volunteer.Id;
    }
}