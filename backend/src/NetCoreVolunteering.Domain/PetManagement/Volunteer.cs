using CSharpFunctionalExtensions;
using NetCoreVolunteering.Domain.PetManagement.Entities;
using NetCoreVolunteering.Domain.PetManagement.ValueObjects;
using NetCoreVolunteering.Domain.Shared;
using NetCoreVolunteering.Domain.Shared.ValueObjects;

namespace NetCoreVolunteering.Domain.PetManagement;

public sealed class Volunteer : Shared.Entity<VolunteerId>
{
    private readonly List<Pet> _pets = [];
    
    // For EF Core
    private Volunteer(VolunteerId id) : base(id) {}

    private Volunteer(
        VolunteerId id,
        FullName fullName,
        Email email,
        Description description,
        ExperienceYears experienceYears,
        PhoneNumber phone,
        SocialNetworksList? socialNetworkList,
        RequisiteList? requisiteList) 
            : base(id)
    {
        FullName = fullName;
        Email = email;
        Description = description;
        Ages = experienceYears;
        Phone = phone;
        SocialsList = socialNetworkList;
        RequisiteList = requisiteList;
    }
    
    public FullName FullName { get; private set; } = default!;
    public Email Email { get; private set; } = default!;
    public Description Description { get; private set; } = default!;
    public ExperienceYears Ages { get; private set; } = default!;
    public PhoneNumber Phone { get; private set; } = default!;
    public IReadOnlyCollection<Pet> Pets => _pets;
    public RequisiteList? RequisiteList { get; private set; }
    public SocialNetworksList? SocialsList { get; private set; }
    
    public int AdoptedPetsCount() => Pets.Count(p => p.Status == HelpStatus.Found);
    public int AvailablePetsCount() => Pets.Count(p => p.Status == HelpStatus.LookingForHome);
    public int PetsInTreatmentCount() => Pets.Count(p => p.Status == HelpStatus.NeedsHelp);
    
    public static Result<Volunteer, Error> Create(
        VolunteerId id,
        FullName fullName, 
        Email email,
        Description description,
        ExperienceYears experienceYears,
        PhoneNumber phone,
        SocialNetworksList? socialNetworkList,
        RequisiteList? requisiteList)
    {
        return new Volunteer(
            id, 
            fullName, 
            email, 
            description, 
            experienceYears, 
            phone, 
            socialNetworkList, 
            requisiteList);
    }
}
