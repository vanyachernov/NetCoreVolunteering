using NetCoreVolunteering.Domain.Enums;
using NetCoreVolunteering.Domain.Models.Pets;
using NetCoreVolunteering.Domain.Models.Volunteers.IDs;
using NetCoreVolunteering.Domain.Models.Volunteers.ValueObjects;
using NetCoreVolunteering.Domain.Shared;
using Description = NetCoreVolunteering.Domain.Models.Pets.ValueObjects.Description;
using PhoneNumber = NetCoreVolunteering.Domain.Models.Pets.ValueObjects.PhoneNumber;

namespace NetCoreVolunteering.Domain.Models.Volunteers;

public class Volunteer : Entity<VolunteerId>
{
    private readonly List<Pet> _pets = [];
    private readonly List<SocialNetwork> _socialNetworks = [];
    private readonly List<Requisite> _paymentDetails = [];
    
    // For EF Core
    private Volunteer(VolunteerId volunteerId) : base(volunteerId) {}

    public Volunteer(
        VolunteerId volunteerId,
        FullName fullName,
        Email email,
        Description description,
        ExperienceYears experienceYears,
        PhoneNumber phone) 
            : base(volunteerId)
    {
        FullName = fullName;
        Email = email;
        Description = description;
        Ages = experienceYears;
        Phone = phone;
    }
    
    public FullName FullName { get; } = default!;
    public Email Email { get; } = default!;
    public Description Description { get; } = default!;
    public ExperienceYears Ages { get; } = default!;
    public PhoneNumber Phone { get; } = default!;
    public IReadOnlyCollection<Pet> Pets => _pets;
    public IReadOnlyCollection<SocialNetwork> SocialNetworks => _socialNetworks;
    public IReadOnlyCollection<Requisite> PaymentDetails => _paymentDetails;
    
    public int AdoptedPetsCount() => Pets.Count(p => p.Status == HelpStatus.Found);
    public int AvailablePetsCount() => Pets.Count(p => p.Status == HelpStatus.LookingForHome);
    public int PetsInTreatmentCount() => Pets.Count(p => p.Status == HelpStatus.NeedsHelp);
}
