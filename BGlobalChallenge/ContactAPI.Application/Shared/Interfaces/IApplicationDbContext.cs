using Microsoft.EntityFrameworkCore;

namespace ContactAPI.Application.Shared.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Domain.Entities.Contact> Contacts { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}