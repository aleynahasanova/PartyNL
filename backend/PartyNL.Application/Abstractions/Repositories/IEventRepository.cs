using PartyNL.Domain.Entities;

namespace PartyNL.Application.Abstractions.Repositories;

public interface IEventRepository
{
	Task<Event?> GetByIdAsync(Guid id);

	Task<IEnumerable<Event>> GetAllAsync();

	Task AddAsync(Event @event);

	Task UpdateAsync(Event @event);

	Task DeleteAsync(Event @event);
}
