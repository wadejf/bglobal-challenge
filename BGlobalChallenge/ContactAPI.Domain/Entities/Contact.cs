using ContactAPI.Domain.Shared;
using ContactAPI.Domain.ValueObjects;

namespace ContactAPI.Domain.Entities;

public class Contact : Entity
{
    public string Name { get; set; }

    public string Company { get; set; }

    public string ProfileImage { get; set; }

    public string Email { get; set; }

    public DateTime BirthDate { get; set; }

    public string PersonalPhone { get; set; }

    public string? WorkPhone { get; set; }

    public Address Address { get; set; }
}