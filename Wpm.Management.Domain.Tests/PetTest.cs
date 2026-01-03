using Wpm.Management.Domain.Entities;
using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Domain.Tests;

public class PetTest
{
    [Fact]
    public void Pet_should_be_equal()
    {
        var id = Guid.NewGuid();
        var pet1 = new Pet(id, "Andre", 13, "Brown", new Weight(20.5m), SexOfPet.Male);
        var pet2 = new Pet(id, "Tina", 11, "White", new Weight(20.5m), SexOfPet.Female);

        Assert.True(pet1.Equals(pet2));
    }

    [Fact]
    public void Pet_should_be_equal_using_operators()
    {
        var id = Guid.NewGuid();
        var pet1 = new Pet(id, "Andre", 13, "Brown", new Weight(20.5m), SexOfPet.Male);
        var pet2 = new Pet(id, "Tina", 11, "White", new Weight(20.5m), SexOfPet.Female);

        Assert.True(pet1 == pet2);
    }

    [Fact]
    public void Pet_should_not_be_equal_using_operators()
    {
        var id1 = Guid.NewGuid();
        var id2 = Guid.NewGuid();

        var pet1 = new Pet(id1, "Andre", 13, "Brown", new Weight(20.5m), SexOfPet.Male);
        var pet2 = new Pet(id2, "Tina", 11, "White", new Weight(20.5m), SexOfPet.Female);

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
}