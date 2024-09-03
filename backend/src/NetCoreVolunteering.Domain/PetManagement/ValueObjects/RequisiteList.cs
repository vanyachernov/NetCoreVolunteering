using NetCoreVolunteering.Domain.Shared.ValueObjects;

namespace NetCoreVolunteering.Domain.PetManagement.ValueObjects;

public record RequisiteList
{
    private RequisiteList() { }

    public RequisiteList(IEnumerable<Requisite> requisites)
    {
        Requisites = requisites.ToList();
    }
    
    public IReadOnlyList<Requisite> Requisites { get; }
};