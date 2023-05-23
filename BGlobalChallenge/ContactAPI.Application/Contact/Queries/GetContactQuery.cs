using ContactAPI.Application.Shared.Exceptions;
using ContactAPI.Application.Shared.Interfaces;
using MediatR;

namespace ContactAPI.Application.Contact.Queries;

public record GetContactQuery(int Id) : IRequest<Domain.Entities.Contact>;

public class GetContactQueryHandler : IRequestHandler<GetContactQuery, Domain.Entities.Contact>
{
    private readonly IApplicationDbContext _context;

    public GetContactQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Domain.Entities.Contact> Handle(GetContactQuery request, CancellationToken cancellationToken)
    {
        var contact = await _context.Contacts.FindAsync(request.Id);

        if (contact == null) throw new NotFoundException(nameof(Contact), request.Id);

        return contact;
    }
}