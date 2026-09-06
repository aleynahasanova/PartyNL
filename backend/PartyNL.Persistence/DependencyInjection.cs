using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PartyNL.Application.Abstractions.Repositories;
using PartyNL.Persistence.Context;
using PartyNL.Persistence.Repositories;

namespace PartyNL.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<PartyNLDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("PartyNLDatabase")));

        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
