using ContactAPI.Application.Shared.Exceptions;
using ContactAPI.Application.Shared.Interfaces;
using MediatR;

namespace ContactAPI.Application.Contact.Delete;

public record DeleteContactCommand(int Id) : IRequest;

public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteContactCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteContactCommand request, CancellationToken cancellationToken)
    {
        var contact = await _context.Contacts
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (contact == null) throw new NotFoundException(nameof(Contact), request.Id);

        _context.Contacts.Remove(contact);

        await _context.SaveChangesAsync(cancellationToken);
    }
}