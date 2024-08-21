using NetCoreVolunteering.Domain.Shared.ValueObjects;

namespace NetCoreVolunteering.Domain.Models.Pets.Lists;

public record RequisiteList
{
    public List<Requisite> Requisites { get; }
};