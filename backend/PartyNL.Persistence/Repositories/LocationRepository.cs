using Microsoft.EntityFrameworkCore;
using PartyNL.Application.Abstractions.Repositories;
using PartyNL.Domain.Entities;
using PartyNL.Persistence.Context;

namespace PartyNL.Persistence.Repositories;

public class LocationRepository : ILocationRepository
{
	private readonly PartyNLDbContext _context;

	public LocationRepository(PartyNLDbContext context)
	{
		_context = context;
	}

	public Task<Location?> GetByIdAsync(Guid id)
	{
		return _context.Locations.AsNoTracking().FirstOrDefaultAsync(location => location.Id == id);
	}

	public async Task<IEnumerable<Location>> GetAllAsync()
	{
		return await _context.Locations.AsNoTracking().ToListAsync();
	}

	public async Task AddAsync(Location location)
	{
		await _context.Locations.AddAsync(location);
	}

	public Task UpdateAsync(Location location)
	{
		_context.Locations.Update(location);
		return Task.CompletedTask;
	}

	public Task DeleteAsync(Location location)
	{
		_context.Locations.Remove(location);
		return Task.CompletedTask;
	}
}
