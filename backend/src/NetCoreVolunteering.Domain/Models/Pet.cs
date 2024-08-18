using NetCoreVolunteering.Domain.Enums;

namespace NetCoreVolunteering.Domain.Models;

public class Pet
{
    private Pet(
        Guid id, 
        string name, 
        Species species, 
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
        HelpStatus status, 
        Props paymentDetails)
    {
        Id = id;
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
        PaymentDetails = paymentDetails;
        CreatedAt = DateTime.UtcNow;
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; } = default!;
    public Species Species { get; private set; } 
    public string Description { get; private set; } = default!;
    public Breed Breed { get; private set; }
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
    public Props PaymentDetails { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public static Pet Create(
        Guid id,
        string name,
        Species species,
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
        HelpStatus status,
        Props paymentDetails)
    {
        return new Pet(id, name, species, description, breed, color, healthInfo, address, weight, height, phoneNumber,
            isNeutered, birthAt, isVaccinated, status, paymentDetails);
    }
}