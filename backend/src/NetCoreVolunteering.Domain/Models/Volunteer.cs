using NetCoreVolunteering.Domain.Enums;
using NetCoreVolunteering.Domain.Models.Pets;

namespace NetCoreVolunteering.Domain.Models;

public class Volunteer
{
    private readonly List<Pet> _pets = [];
    private readonly List<SocialNetwork> _socialNetworks = [];
    private readonly List<Requisite> _paymentDetails = [];
    
    // For EF Core
    private Volunteer() {}
    
    public Guid Id { get; private set; }
    public string FullName { get; private set; } = default!;
    public string Email { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public int ExperienceYears { get; private set; } = 0;
    public int AdoptedPetsCount() => Pets.Count(p => p.Status == HelpStatus.Found);
    public int AvailablePetsCount() => Pets.Count(p => p.Status == HelpStatus.LookingForHome);
    public int PetsInTreatmentCount() => Pets.Count(p => p.Status == HelpStatus.NeedsHelp);
    public string Phone { get; private set; } = default!;
    public IReadOnlyCollection<Pet> Pets => _pets;
    public IReadOnlyCollection<SocialNetwork> SocialNetworks => _socialNetworks;
    public IReadOnlyCollection<Requisite> PaymentDetails => _paymentDetails;
}