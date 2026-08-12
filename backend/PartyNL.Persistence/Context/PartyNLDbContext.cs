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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PartyNLDbContext).Assembly);
    }
}