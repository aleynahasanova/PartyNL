using Microsoft.EntityFrameworkCore;
using PartyNL.Application.Abstractions.Repositories;
using PartyNL.Domain.Entities;
using PartyNL.Persistence.Context;

namespace PartyNL.Persistence.Repositories;

public class OrganizerRepository : IOrganizerRepository
{
	private readonly PartyNLDbContext _context;

	public OrganizerRepository(PartyNLDbContext context)
	{
		_context = context;
	}

	public Task<Organizer?> GetByIdAsync(Guid id)
	{
		return _context.Organizers.AsNoTracking().FirstOrDefaultAsync(organizer => organizer.Id == id);
	}

	public async Task<IEnumerable<Organizer>> GetAllAsync()
	{
		return await _context.Organizers.AsNoTracking().ToListAsync();
	}

	public async Task AddAsync(Organizer organizer)
	{
		await _context.Organizers.AddAsync(organizer);
	}

	public Task UpdateAsync(Organizer organizer)
	{
		_context.Organizers.Update(organizer);
		return Task.CompletedTask;
	}

	public Task DeleteAsync(Organizer organizer)
	{
		_context.Organizers.Remove(organizer);
		return Task.CompletedTask;
	}
}
