using ContactAPI.Application.Shared.Interfaces;
using ContactAPI.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace ContactAPI.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseInMemoryDatabase("ContactDb"));

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        return services;
    }
}