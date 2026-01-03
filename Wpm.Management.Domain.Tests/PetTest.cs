using Wpm.Management.Domain.Entities;
using Wpm.Management.Domain.ValueObjects;
using Wpm.SharedKernel;

namespace Wpm.Management.Domain.Tests;

public class PetTest
{
    [Fact]
    public void Pet_should_be_equal()
    {
        var id = Guid.NewGuid();

        var breedService = new FakeBreedService();
        var breedId = new BreedId(breedService.breeds[0].Id, breedService);

        var pet1 = new Pet(id, "Andre", 13, "Brown", SexOfPet.Male, breedId);
        var pet2 = new Pet(id, "Tina", 11, "White", SexOfPet.Female, breedId);

        Assert.True(pet1.Equals(pet2));
    }

    [Fact]
    public void Pet_should_be_equal_using_operators()
    {
        var id = Guid.NewGuid();

        var breedService = new FakeBreedService();
        var breedId = new BreedId(breedService.breeds[0].Id, breedService);

        var pet1 = new Pet(id, "Andre", 13, "Brown", SexOfPet.Male, breedId);
        var pet2 = new Pet(id, "Tina", 11, "White", SexOfPet.Female, breedId);

        Assert.True(pet1 == pet2);
    }

    [Fact]
    public void Pet_should_not_be_equal_using_operators()
    {
        var id1 = Guid.NewGuid();
        var id2 = Guid.NewGuid();

        var breedService = new FakeBreedService();
        var breedId = new BreedId(breedService.breeds[0].Id, breedService);

        var pet1 = new Pet(id1, "Andre", 13, "Brown", SexOfPet.Male, breedId);
        var pet2 = new Pet(id2, "Tina", 11, "White", SexOfPet.Female, breedId);

        Assert.True(pet1 != pet2);
    }

    [Fact]
    public void Weight_should_be_equal() 
    {
        var w1 = new Weight(20.5m);
        var w2 = new Weight(20.5m);

        Assert.True(w1 == w2);
    }

    [Fact]
    public void Weight_should_not_be_equal()
    {
        var w1 = new Weight(20.5m);
        var w2 = new Weight(100.5m);

        Assert.True(w1 != w2);
    }

    [Fact]
    public void WeightRange_should_be_equal()
    {
        var wr1 = new WeightRange(20.5m, 30.5m);
        var wr2 = new WeightRange(20.5m, 30.5m);

        Assert.True(wr1 == wr2);
    }

    [Fact]
    public void WeightRange_should_not_be_equal()
    {
        var wr1 = new WeightRange(20.5m, 30.5m);
        var wr2 = new WeightRange(20.5m, 320.5m);

        Assert.True(wr1 != wr2);
    }

    [Fact]
    public void BreedId_should_be_valid() 
    {
        var breedService = new FakeBreedService();
        var id = breedService.breeds[0].Id;
        var breedId = new BreedId(id, breedService);

        Assert.NotNull(breedId);
    }

    [Fact]
    public void BreedId_should_not_be_valid()
    {
        var breedService = new FakeBreedService();
        var id = Guid.NewGuid();

        Assert.Throws<ArgumentException>(() =>
        {
            var breedId = new BreedId(id, breedService);
        });
    }

    [Fact]
    public void WeightClass_should_be_ideal() 
    {
        var breedService = new FakeBreedService();
        var breedId = new BreedId(breedService.breeds[0].Id, breedService);

        var pet = new Pet(Guid.NewGuid(), "Andre", 13, "Brown", SexOfPet.Male, breedId);
        pet.SetWeight(10, breedService);

        Assert.True(pet.WeightClass == WeightClass.Ideal);
    }

    [Fact]
    public void WeightClass_should_be_overweight()
    {
        var breedService = new FakeBreedService();
        var breedId = new BreedId(breedService.breeds[0].Id, breedService);

        var pet = new Pet(Guid.NewGuid(), "Andre", 13, "Brown", SexOfPet.Male, breedId);
        pet.SetWeight(21, breedService);

        Assert.True(pet.WeightClass == WeightClass.Overweight);
    }

}