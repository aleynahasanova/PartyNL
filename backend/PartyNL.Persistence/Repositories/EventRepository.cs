using Microsoft.EntityFrameworkCore;
using PartyNL.Application.Abstractions.Repositories;
using PartyNL.Domain.Entities;
using PartyNL.Persistence.Context;

namespace PartyNL.Persistence.Repositories;

public class EventRepository : IEventRepository
{
	private readonly PartyNLDbContext _context;

	public EventRepository(PartyNLDbContext context)
	{
		_context = context;
	}

	public Task<Event?> GetByIdAsync(Guid id)
	{
		return _context.Events.AsNoTracking().FirstOrDefaultAsync(@event => @event.Id == id);
	}

	public async Task<IEnumerable<Event>> GetAllAsync()
	{
		return await _context.Events.AsNoTracking().ToListAsync();
	}

	public async Task AddAsync(Event @event)
	{
		await _context.Events.AddAsync(@event);
	}

	public Task UpdateAsync(Event @event)
	{
		_context.Events.Update(@event);
		return Task.CompletedTask;
	}

	public Task DeleteAsync(Event @event)
	{
		_context.Events.Remove(@event);
		return Task.CompletedTask;
	}
}
