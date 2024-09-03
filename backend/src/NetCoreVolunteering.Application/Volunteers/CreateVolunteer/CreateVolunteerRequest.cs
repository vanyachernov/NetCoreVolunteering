using NetCoreVolunteering.Application.DTOs;

namespace NetCoreVolunteering.Application.Volunteers.CreateVolunteer;

public record CreateVolunteerRequest(
    FullNameDto FullNameDto,
    string Email, 
    string Description,
    int ExperienceYears,
    string Phone, 
    IEnumerable<SocialNetworksDto>? SocialNetworks,
    IEnumerable<RequisiteDto>? Requisites);