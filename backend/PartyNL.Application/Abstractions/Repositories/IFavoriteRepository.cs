using PartyNL.Domain.Entities;

namespace PartyNL.Application.Abstractions.Repositories;

public interface IFavoriteRepository
{
	Task<Favorite?> GetByIdAsync(Guid userId, Guid eventId);

	Task<IEnumerable<Favorite>> GetAllAsync();

	Task AddAsync(Favorite favorite);

	Task UpdateAsync(Favorite favorite);

	Task DeleteAsync(Favorite favorite);
}
