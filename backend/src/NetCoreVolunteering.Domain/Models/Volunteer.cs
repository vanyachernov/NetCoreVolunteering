using NetCoreVolunteering.Domain.Enums;

namespace NetCoreVolunteering.Domain.Models;

public class Volunteer
{
    private readonly List<Pet> _pets = [];
    private readonly List<SocialNetwork> _socialNetworks = [];
    private readonly List<Props> _paymentDetails = [];
    
    public Guid Id { get; private set; }
    public string FullName { get; private set; } = default!;
    public string Email { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public int ExperienceYears { get; private set; } = 0;
    public int AdoptedPetsCount() => Pets.Select(p => p.Status == HelpStatus.Found).Count();
    public int AvailablePetsCount() => Pets.Select(p => p.Status == HelpStatus.LookingForHome).Count();
    public int PetsInTreatmentCount() => Pets.Select(p => p.Status == HelpStatus.NeedsHelp).Count();
    public string Phone { get; private set; } = default!;
    public IReadOnlyCollection<Pet> Pets => _pets;
    public IReadOnlyCollection<SocialNetwork> SocialNetworks => _socialNetworks;
    public IReadOnlyCollection<Props> PaymentDetails => _paymentDetails;
}