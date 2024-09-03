using FluentValidation;
using NetCoreVolunteering.Application.Validation;
using NetCoreVolunteering.Domain.PetManagement.ValueObjects;
using NetCoreVolunteering.Domain.Shared.ValueObjects;

namespace NetCoreVolunteering.Application.Volunteers.CreateVolunteer;

public class CreateVolunteerRequestValidator : AbstractValidator<CreateVolunteerRequest>
{
    public CreateVolunteerRequestValidator()
    {
        RuleFor(c => c.FullNameDto).MustBeValueObject(f => FullName.Create(f.FirstName, f.MiddleName, f.LastName));
        
        RuleFor(c => c.Email).MustBeValueObject(Email.Create);
        
        RuleFor(c => c.ExperienceYears).MustBeValueObject(ExperienceYears.Create);
        
        RuleFor(c => c.Phone).MustBeValueObject(PhoneNumber.Create);
        
        RuleForEach(v => v.Requisites)
            .MustBeValueObject(x =>
                Requisite.Create(
                    x.Title,
                    x.Description));

        RuleForEach(v => v.SocialNetworks)
            .MustBeValueObject(x =>
                SocialNetwork.Create(
                    x.Link,
                    x.Title));
    }
}