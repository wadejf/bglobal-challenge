using ContactAPI.Application.Shared.Exceptions;
using ContactAPI.Application.Shared.Interfaces;
using ContactAPI.Domain.ValueObjects;
using MediatR;

namespace ContactAPI.Application.Contact.Update;

public record UpdateContactCommand(int Id) : IRequest<Domain.Entities.Contact>
{
    public string? Name { get; init; }

    public string? Company { get; init; }

    public string? ProfileImage { get; init; }

    public string? Email { get; init; }

    public DateTime BirthDate { get; init; }

    public string? PersonalPhone { get; init; }

    public string? WorkPhone { get; init; }

    public Address? Address { get; init; }
}

public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, Domain.Entities.Contact>
{
    private readonly IApplicationDbContext _context;

    public UpdateContactCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Domain.Entities.Contact> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
    {
        var contact = await _context.Contacts
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (contact == null) throw new NotFoundException(nameof(Contact), request.Id);

        if (!string.IsNullOrEmpty(request.Name)) contact.Name = request.Name;
        if (!string.IsNullOrEmpty(request.Company)) contact.Company = request.Company;
        if (!string.IsNullOrEmpty(request.ProfileImage)) contact.ProfileImage = request.ProfileImage;
        if (!string.IsNullOrEmpty(request.Email)) contact.Email = request.Email;
        if (!string.IsNullOrEmpty(request.PersonalPhone)) contact.PersonalPhone = request.PersonalPhone;
        if (!string.IsNullOrEmpty(request.WorkPhone)) contact.WorkPhone = request.WorkPhone;
        contact.BirthDate = request.BirthDate;
        if (request.Address is not null) contact.Address = request.Address;

        return contact;
    }
}