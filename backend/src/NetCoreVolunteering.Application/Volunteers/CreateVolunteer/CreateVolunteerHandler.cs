using CSharpFunctionalExtensions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using NetCoreVolunteering.Domain.PetManagement;
using NetCoreVolunteering.Domain.PetManagement.ValueObjects;
using NetCoreVolunteering.Domain.Shared;
using NetCoreVolunteering.Domain.Shared.ValueObjects;

namespace NetCoreVolunteering.Application.Volunteers.CreateVolunteer;

public class CreateVolunteerHandler(
    IVolunteersRepository volunteersRepository,
    ILogger<CreateVolunteerHandler> logger)
{
    public async Task<Result<Guid, Error>> Handle(
        CreateVolunteerRequest request,
        CancellationToken cancellationToken = default)
    {
        
        var fullName = FullName.Create(request.FullNameDto.FirstName, request.FullNameDto.MiddleName, request.FullNameDto.LastName).Value;
        var email = Email.Create(request.Email).Value;
        var description = Description.Create(request.Description).Value;
        var experienceYears = ExperienceYears.Create(request.ExperienceYears).Value;
        var phone = PhoneNumber.Create(request.Phone).Value;

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
        
        var existingVolunteer = await volunteersRepository.GetByPhone(phone, cancellationToken);

        if (existingVolunteer.IsSuccess)
        {
            return Errors.General.AlreadyExists();
        }
        
        var voluteerId = VolunteerId.NewId();
        
        var volunteerToCreate = Volunteer.Create(
            voluteerId, 
            fullName, 
            email, 
            description, 
            experienceYears, 
            phone,
            socialNetworks,
            requisites);
        
        if (volunteerToCreate.IsFailure)
        {
            return volunteerToCreate.Error;
        }
        
        await volunteersRepository.Create(volunteerToCreate.Value, cancellationToken);

        logger.LogInformation("Created volunteer {fullName} with id {voluteerId}", fullName, voluteerId);
        
        return (Guid)volunteerToCreate.Value.Id;
    }
}