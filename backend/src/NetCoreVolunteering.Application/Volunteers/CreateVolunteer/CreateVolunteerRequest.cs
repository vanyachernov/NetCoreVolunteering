using NetCoreVolunteering.Application.DTOs;

namespace NetCoreVolunteering.Application.Volunteers.CreateVolunteer;

public record CreateVolunteerRequest(
    string FirstName, 
    string MiddleName, 
    string LastName, 
    string Email, 
    string Description,
    int ExperienceYears,
    string Phone,
    IEnumerable<SocialNetworksDto>? SocialNetworks,
    IEnumerable<RequisiteDto>? Requisites);