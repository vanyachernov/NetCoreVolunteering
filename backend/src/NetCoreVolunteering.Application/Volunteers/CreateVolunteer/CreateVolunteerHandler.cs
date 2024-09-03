using CSharpFunctionalExtensions;
using NetCoreVolunteering.Domain.PetManagement;
using NetCoreVolunteering.Domain.PetManagement.ValueObjects;
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
        
        var volunteerEmail = Email.Create(request.Email);
        
        var volunteerDescription = Description.Create(request.Description);
        
        var volunteerExperienceYears = ExperienceYears.Create(request.ExperienceYears);
        
        var volunteerPhone = PhoneNumber.Create(request.Phone);

        var socialNetworks = new SocialNetworksList(
            request.SocialNetworks
                .Select(s => SocialNetwork.Create(s.Link, s.Link))
                .Select(result => result.Value)
                .ToList());

        var requisites = new RequisiteList(
            request.Requisites
                .Select(r => Requisite.Create(r.Title, r.Description))
                .Select(result => result.Value)
                .ToList());
        
        var existingVolunteer = await volunteersRepository.GetByPhone(volunteerPhone.Value, cancellationToken);

        if (existingVolunteer.IsSuccess)
        {
            return Errors.General.AlreadyExists();
        }
        
        var voluteerId = VolunteerId.NewId();
        
        var volunteerToCreate = Volunteer.Create(
            voluteerId, 
            volunteerFullName.Value, 
            volunteerEmail.Value, 
            volunteerDescription.Value, 
            volunteerExperienceYears.Value, 
            volunteerPhone.Value,
            socialNetworks,
            requisites);
        
        if (volunteerToCreate.IsFailure)
        {
            return volunteerToCreate.Error;
        }
        
        await volunteersRepository.Create(volunteerToCreate.Value, cancellationToken);

        return (Guid)volunteerToCreate.Value.Id;
    }
}