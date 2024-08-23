using NetCoreVolunteering.Application.DTOs;

namespace NetCoreVolunteering.Application.Volunteers.CreateVolunteer;

public record CreateVolunteerRequest(
    string firstName, 
    string middleName, 
    string lastName, 
    string email, 
    string description,
    int experienceYears,
    string phone,
    IEnumerable<SocialNetworksDto>? socialNetworks,
    IEnumerable<RequisiteDto>? requisites);