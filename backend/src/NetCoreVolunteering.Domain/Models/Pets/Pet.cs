using NetCoreVolunteering.Domain.Enums;
using NetCoreVolunteering.Domain.Models.Pets.IDs;
using NetCoreVolunteering.Domain.Models.Pets.ValueObjects;
using NetCoreVolunteering.Domain.Models.Species;
using NetCoreVolunteering.Domain.Models.Species.IDs;
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
        SpeciesId speciesId, 
        Description description, 
        BreedId breedId, 
        Color color, 
        HealthInfo healthInfo, 
        Address address, 
        PetAttributes petAttributes,
        PhoneNumber phone, 
        bool isNeutered, 
        DateTime birthAt, 
        bool isVaccinated, 
        HelpStatus status)
    : base(petId)
    {
        
        Name = name;
        SpeciesId = speciesId;
        Description = description;
        BreedId = breedId;
        Color = color;
        HealthInfo = healthInfo;
        Address = address;
        PetAttributes = petAttributes;
        Phone = phone;
        IsNeutered = isNeutered;
        BirthAt = birthAt;
        IsVaccinated = isVaccinated;
        Status = status;
        CreatedAt = DateTime.UtcNow;
    }
    
    public string Name { get; } = default!;
    public SpeciesId SpeciesId { get; } = default!;
    public Description Description { get; } = default!;
    public BreedId BreedId { get; } = default!;
    public Color Color { get; } = default!;
    public HealthInfo HealthInfo { get; } = default!;
    public Address Address { get; } = default!;
    public PetAttributes PetAttributes { get; } = default!;
    public PhoneNumber Phone { get; } =  default!;
    public bool IsNeutered { get; }
    public DateTime BirthAt { get; }
    public bool IsVaccinated { get; }
    public HelpStatus Status { get; }
    public DateTime CreatedAt { get; }
    public IReadOnlyCollection<Requisite> PaymentDetails => _requisites;
    public IReadOnlyCollection<PetPhoto> Images => _petPhotos;

    public static Pet Create(
        PetId petId,
        string name,
        SpeciesId speciesId,
        Description description,
        BreedId breedId,
        Color color,
        HealthInfo healthInfo,
        Address address,
        PetAttributes petAttributes,
        PhoneNumber phone,
        bool isNeutered,
        DateTime birthAt,
        bool isVaccinated,
        HelpStatus status)
    {
        // So far.
        return new Pet(petId, name, speciesId, description, breedId, color, healthInfo, address, petAttributes, phone,
            isNeutered, birthAt, isVaccinated, status);
    }
}