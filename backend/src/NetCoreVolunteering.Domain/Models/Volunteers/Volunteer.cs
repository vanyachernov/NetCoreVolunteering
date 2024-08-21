using NetCoreVolunteering.Domain.Enums;
using NetCoreVolunteering.Domain.Models.Pets;
using NetCoreVolunteering.Domain.Models.Volunteers.IDs;
using NetCoreVolunteering.Domain.Models.Volunteers.ValueObjects;
using NetCoreVolunteering.Domain.Shared;
using NetCoreVolunteering.Domain.Shared.ValueObjects;

namespace NetCoreVolunteering.Domain.Models.Volunteers;

public sealed class Volunteer : Entity<VolunteerId>
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
    
    public FullName FullName { get; private set; } = default!;
    public Email Email { get; private set; } = default!;
    public Description Description { get; private set; } = default!;
    public ExperienceYears Ages { get; private set; } = default!;
    public PhoneNumber Phone { get; private set; } = default!;
    public IReadOnlyCollection<Pet> Pets => _pets;
    public IReadOnlyCollection<SocialNetwork> SocialNetworks => _socialNetworks;
    public IReadOnlyCollection<Requisite> PaymentDetails => _paymentDetails;
    
    public int AdoptedPetsCount() => Pets.Count(p => p.Status == HelpStatus.Found);
    public int AvailablePetsCount() => Pets.Count(p => p.Status == HelpStatus.LookingForHome);
    public int PetsInTreatmentCount() => Pets.Count(p => p.Status == HelpStatus.NeedsHelp);
}
