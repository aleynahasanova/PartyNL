using Microsoft.EntityFrameworkCore;
using PartyNL.Domain.Entities;

namespace PartyNL.Persistence.Context;

public class PartyNLDbContext : DbContext
{
    public PartyNLDbContext(DbContextOptions<PartyNLDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Organizer> Organizers => Set<Organizer>();
    public DbSet<Event> Events => Set<Event>();
    public DbSet<Location> Locations => Set<Location>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Attendance> Attendances => Set<Attendance>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PartyNLDbContext).Assembly);
    }
}