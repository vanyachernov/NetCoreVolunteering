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

        var volunteerFullName = FullName.Create(request.FirstName, request.MiddleName, request.LastName);
        var volunteerEmail = Email.Create(request.Email);
        var volunteerDescription = Description.Create(request.Description);
        var volunteerExperienceYears = ExperienceYears.Create(request.ExperienceYears);
        var volunteerPhone = PhoneNumber.Create(request.Phone);

        var volunteer = Volunteer.Create(voluteerId, volunteerFullName.Value, volunteerEmail.Value, volunteerDescription.Value, volunteerExperienceYears.Value, volunteerPhone.Value);
        
        if (volunteer.IsFailure)
        {
            return volunteer.Error;
        }
        
        await volunteersRepository.Create(volunteer.Value, cancellationToken);

        return (Guid)volunteer.Value.Id;
    }
}