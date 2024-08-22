namespace NetCoreVolunteering.Domain.Models.Species.Lists;

public record BreedList
{
    private readonly List<Breed> _breeds = [];

    public IReadOnlyList<Breed> Breeds => _breeds;

    public void AddBreeds(List<Breed> breeds) => _breeds.AddRange(breeds);
}