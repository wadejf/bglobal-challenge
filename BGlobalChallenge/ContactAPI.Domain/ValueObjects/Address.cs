using ContactAPI.Domain.Shared;

namespace ContactAPI.Domain.ValueObjects;

public class Address : ValueObject
{
    public string Street { get; init; }

    public string StreetNumber { get; init; }

    public string City { get; init; }

    public string State { get; init; }

    public string Country { get; init; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Street;
        yield return StreetNumber;
        yield return City;
        yield return State;
        yield return Country;
    }
}