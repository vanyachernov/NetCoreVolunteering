using NetCoreVolunteering.Domain.Enums;
using NetCoreVolunteering.Domain.Models.Pets.IDs;
using NetCoreVolunteering.Domain.Models.Species;
using NetCoreVolunteering.Domain.Shared;

namespace NetCoreVolunteering.Domain.Models.Pets;

public class Pet : Entity<PetId>
{
    private readonly List<PetPhoto> _petPhotos = [];
    private readonly List<Requisite> _requisites = [];
    
    // For EF Core
    private Pet(PetId petId) : base(petId) {}
    
    private Pet(
        PetId petId,
        string name, 
        Species.Species species, 
        string description, 
        Breed breed, 
        string color, 
        string healthInfo, 
        string address, 
        double weight, 
        double height,
        string phoneNumber, 
        bool isNeutered, 
        DateTime birthAt, 
        bool isVaccinated, 
        HelpStatus status)
    : base(petId)
    {
        
        Name = name;
        Species = species;
        Description = description;
        Breed = breed;
        Color = color;
        HealthInfo = healthInfo;
        Address = address;
        Weight = weight;
        Height = height;
        PhoneNumber = phoneNumber;
        IsNeutered = isNeutered;
        BirthAt = birthAt;
        IsVaccinated = isVaccinated;
        Status = status;
        CreatedAt = DateTime.UtcNow;
    }
    
    public Guid Id { get; private set; }
    public string Name { get; private set; } = default!;
    public Species.Species Species { get; private set; } 
    public string Description { get; private set; } = default!;
    public Breed Breed  { get; private set; }
    public string Color { get; private set; } = default!;
    public string HealthInfo { get; private set; } = default!;
    public string Address { get; private set; } = default!;
    public double Weight { get; private set; }
    public double Height { get; private set; }
    public string PhoneNumber { get; private set; } =  default!;
    public bool IsNeutered { get; private set; }
    public DateTime BirthAt { get; private set; }
    public bool IsVaccinated { get; private set; }
    public HelpStatus Status { get; private set; }
    public IReadOnlyCollection<Requisite> PaymentDetails => _requisites;
    public DateTime CreatedAt { get; private set; }
    public IReadOnlyCollection<PetPhoto> Images => _petPhotos;

    public static Pet Create(
        PetId petId,
        string name,
        Species.Species species,
        string description,
        Breed breed,
        string color,
        string healthInfo,
        string address,
        double weight,
        double height,
        string phoneNumber,
        bool isNeutered,
        DateTime birthAt,
        bool isVaccinated,
        HelpStatus status)
    {
        // So far.
        return new Pet(petId, name, species, description, breed, color, healthInfo, address, weight, height, phoneNumber,
            isNeutered, birthAt, isVaccinated, status);
    }
}