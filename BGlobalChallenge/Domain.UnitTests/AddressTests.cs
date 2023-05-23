using ContactAPI.Domain.ValueObjects;

namespace Domain.UnitTests;

[TestFixture]
public class AddressTests
{
    [Test]
    public void TestEquality()
    {
        var address1 = new Address
        {
            Street = "9 de Julio",
            StreetNumber = "1234",
            City = "Belgrano",
            State = "CABA",
            Country = "Argentina"
        };

        var address2 = new Address
        {
            Street = "9 de Julio",
            StreetNumber = "1234",
            City = "Belgrano",
            State = "CABA",
            Country = "Argentina"
        };

        var result = address1.Equals(address2);

        Assert.That(result, Is.True);
    }

    [Test]
    public void TestInequality()
    {
        var address1 = new Address
        {
            Street = "9 de Julio",
            StreetNumber = "1234",
            City = "Buenos Aires",
            State = "CABA",
            Country = "Argentina"
        };

        var address2 = new Address
        {
            Street = "Juan Jose Castelli",
            StreetNumber = "6524",
            City = "Villa Adelina",
            State = "Buenos Aires",
            Country = "Argentina"
        };

        var result = address1.Equals(address2);

        Assert.That(result, Is.False);
    }
}