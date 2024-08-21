using CSharpFunctionalExtensions;
using NetCoreVolunteering.Domain.Enums;
using NetCoreVolunteering.Domain.Models.Pets.IDs;
using NetCoreVolunteering.Domain.Models.Pets.Lists;
using NetCoreVolunteering.Domain.Models.Pets.ValueObjects;
using NetCoreVolunteering.Domain.Models.Species.IDs;
using NetCoreVolunteering.Domain.Models.Volunteers.ValueObjects;
using NetCoreVolunteering.Domain.Shared;
using NetCoreVolunteering.Domain.Shared.ValueObjects;

namespace NetCoreVolunteering.Domain.Models.Pets;

public class Pet : Shared.Entity<PetId>
{
    // For EF Core
    private Pet(PetId id) : base(id) {}
    
    private Pet(
        PetId id,
        string name, 
        SpeciesId speciesId, 
        Description description, 
        Guid breedId, 
        Color color, 
        HealthInfo healthInfo, 
        Address address, 
        PetAttributes petAttributes,
        PhoneNumber phone, 
        bool isNeutered, 
        DateTime birthAt, 
        bool isVaccinated, 
        HelpStatus status,
        PetPhotoList petPhotoList,
        RequisiteList requisiteList)
    : base(id)
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
        Images = petPhotoList;
        PaymentDetails = requisiteList;
        CreatedAt = DateTime.UtcNow;
    }
    
    public string Name { get; private set;  } = default!;
    public SpeciesId SpeciesId { get; private set; } = default!;
    public Description Description { get; private set; } = default!;
    public Guid BreedId { get; private set; } = default!;
    public Color Color { get; private set; } = default!;
    public HealthInfo HealthInfo { get; private set; } = default!;
    public Address Address { get; private set; } = default!;
    public PetAttributes PetAttributes { get; private set; } = default!;
    public PhoneNumber Phone { get; private set; } = default!;
    public bool IsNeutered { get; private set; }
    public DateTime BirthAt { get; private set; }
    public bool IsVaccinated { get; private set; }
    public HelpStatus Status { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public PetPhotoList? Images { get; private set; } = default!;
    public RequisiteList PaymentDetails { get; private set; } = default!;

    public static Result<Pet> Create(
        PetId petId,
        string name,
        SpeciesId speciesId,
        Description description,
        Guid breedId,
        Color color,
        HealthInfo healthInfo,
        Address address,
        PetAttributes petAttributes, 
        PhoneNumber phone,
        bool isNeutered,
        DateTime birthAt,
        bool isVaccinated,
        HelpStatus status,
        PetPhotoList petPhotoList,
        RequisiteList requisiteList)
    {
        if (string.IsNullOrEmpty(name) || name.Length > Constants.MAX_LOW_TEXT_LENGTH)
        {
            return Result.Failure<Pet>("Pet name is invalid.");
        }
        
        return new Pet(petId, name, speciesId, description, breedId, color, healthInfo, address, petAttributes, phone,
            isNeutered, birthAt, isVaccinated, status, petPhotoList, requisiteList);
    }
}