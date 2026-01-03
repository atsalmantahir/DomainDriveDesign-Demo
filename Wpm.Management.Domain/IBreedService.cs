using Wpm.Management.Domain.Entities;
using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Domain;

public interface IBreedService
{
    Breed? GetBreed(Guid id);
}

public class FakeBreedService : IBreedService 
{
    public readonly List<Breed> breeds =
        [
            new Breed (Guid.NewGuid(), "Beagle", new WeightRange(10m, 20m), new WeightRange(5m, 10m)),
            new Breed (Guid.NewGuid(), "Terrier", new WeightRange(18m, 28m), new WeightRange(15m, 8m))
        ];

    public Breed? GetBreed(Guid id) 
    {
        if (id == Guid.Empty) 
        {
            throw new ArgumentException("Breed is not valid.");
        }

        var result = breeds.Find(breads => breads.Id == id);
        return result ?? throw new ArgumentException("Breed was not found.");
    }
}
