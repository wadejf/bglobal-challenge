using ContactAPI.Application.Shared.Interfaces;
using ContactAPI.Domain.ValueObjects;
using MediatR;

namespace ContactAPI.Application.Contact.Create;

public record CreateContactCommand : IRequest<int>
{
    public string Name { get; init; }

    public string Company { get; init; }

    public string ProfileImage { get; init; }

    public string Email { get; init; }

    public DateTime BirthDate { get; init; }

    public string PersonalPhone { get; init; }

    public string WorkPhone { get; init; }

    public Address Address { get; init; }
}

public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateContactCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateContactCommand request, CancellationToken cancellationToken)
    {
        var contact = new Domain.Entities.Contact
        {
            Name = request.Name,
            Company = request.Company,
            ProfileImage = request.ProfileImage,
            Email = request.Email,
            BirthDate = request.BirthDate,
            PersonalPhone = request.PersonalPhone,
            WorkPhone = request.WorkPhone,
            Address = request.Address,
            CreatedAt = DateTime.Now
        };

        _context.Contacts.Add(contact);

        await _context.SaveChangesAsync(cancellationToken);

        return contact.Id;
    }
}