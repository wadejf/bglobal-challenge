using ContactAPI.Application.Shared.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContactAPI.Application.Contact.Queries;

public class GetAllContactsQuery : IRequest<List<Domain.Entities.Contact>>
{
    public string? Email { get; set; }

    public string? PersonalPhone { get; set; }

    public string? State { get; set; }

    public string? City { get; set; }
}

public class
    GetAllContactsQueryHandler : IRequestHandler<GetAllContactsQuery,
        List<Domain.Entities.Contact>>
{
    private readonly IApplicationDbContext _context;

    public GetAllContactsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Domain.Entities.Contact>> Handle(GetAllContactsQuery request,
        CancellationToken cancellationToken)
    {
        return await _context.Contacts
            .Where(c =>
                (string.IsNullOrEmpty(request.Email) || c.Email == request.Email) &&
                (string.IsNullOrEmpty(request.PersonalPhone) || c.PersonalPhone == request.PersonalPhone) &&
                (string.IsNullOrEmpty(request.State) || c.Address.State.Contains(request.State)) &&
                (string.IsNullOrEmpty(request.City) || c.Address.City.Contains(request.City)))
            .ToListAsync(cancellationToken);
    }
}