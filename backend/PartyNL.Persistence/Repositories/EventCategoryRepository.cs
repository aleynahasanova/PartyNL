using Microsoft.EntityFrameworkCore;
using PartyNL.Application.Abstractions.Repositories;
using PartyNL.Domain.Entities;
using PartyNL.Persistence.Context;

namespace PartyNL.Persistence.Repositories;

public class EventCategoryRepository : IEventCategoryRepository
{
	private readonly PartyNLDbContext _context;

	public EventCategoryRepository(PartyNLDbContext context)
	{
		_context = context;
	}

	public Task<EventCategory?> GetByIdAsync(Guid eventId, Guid categoryId)
	{
		return _context.EventCategories.AsNoTracking()
			.FirstOrDefaultAsync(eventCategory => eventCategory.EventId == eventId
				&& eventCategory.CategoryId == categoryId);
	}

	public async Task<IEnumerable<EventCategory>> GetAllAsync()
	{
		return await _context.EventCategories.AsNoTracking().ToListAsync();
	}

	public async Task AddAsync(EventCategory eventCategory)
	{
		await _context.EventCategories.AddAsync(eventCategory);
	}

	public Task UpdateAsync(EventCategory eventCategory)
	{
		_context.EventCategories.Update(eventCategory);
		return Task.CompletedTask;
	}

	public Task DeleteAsync(EventCategory eventCategory)
	{
		_context.EventCategories.Remove(eventCategory);
		return Task.CompletedTask;
	}
}
