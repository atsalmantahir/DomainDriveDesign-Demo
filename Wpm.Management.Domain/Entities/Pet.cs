using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Domain.Entities;

public class Pet : Entity
{
    public string Name { get; init; }
    public int Age { get; init; }
    public string Color { get; set; }
    public Weight Weight { get; set; }
    public SexOfPet SexOfPet { get; set; }

    public BreedId BreedId { get; set; }

    public Pet(Guid id,
               string name,
               int age,
               string color,
               Weight weight,
               SexOfPet sexOfPet,
               BreedId breadId)
    {
        Id = id;
        Name = name;
        Age = age;
        Color = color;
        Weight = weight;
        SexOfPet = sexOfPet;
        BreedId = breadId;
    }
}

public enum SexOfPet
{
    Male,
    Female
}
