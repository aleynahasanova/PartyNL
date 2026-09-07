using Microsoft.EntityFrameworkCore;
using PartyNL.Application.Abstractions.Repositories;
using PartyNL.Domain.Entities;
using PartyNL.Persistence.Context;

namespace PartyNL.Persistence.Repositories;

public class FavoriteRepository : IFavoriteRepository
{
	private readonly PartyNLDbContext _context;

	public FavoriteRepository(PartyNLDbContext context)
	{
		_context = context;
	}

	public Task<Favorite?> GetByIdAsync(Guid userId, Guid eventId)
	{
		return _context.Favorites.AsNoTracking()
			.FirstOrDefaultAsync(favorite => favorite.UserId == userId && favorite.EventId == eventId);
	}

	public async Task<IEnumerable<Favorite>> GetAllAsync()
	{
		return await _context.Favorites.AsNoTracking().ToListAsync();
	}

	public async Task AddAsync(Favorite favorite)
	{
		await _context.Favorites.AddAsync(favorite);
	}

	public Task UpdateAsync(Favorite favorite)
	{
		_context.Favorites.Update(favorite);
		return Task.CompletedTask;
	}

	public Task DeleteAsync(Favorite favorite)
	{
		_context.Favorites.Remove(favorite);
		return Task.CompletedTask;
	}
}
