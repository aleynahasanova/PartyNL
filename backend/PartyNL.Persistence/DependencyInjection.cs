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
        services.AddScoped<IOrganizerRepository, OrganizerRepository>();
        services.AddScoped<ILocationRepository, LocationRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IEventRepository, EventRepository>();
        services.AddScoped<IAttendanceRepository, AttendanceRepository>();
        services.AddScoped<IFavoriteRepository, FavoriteRepository>();
        services.AddScoped<IEventCategoryRepository, EventCategoryRepository>();

        return services;
    }
}
