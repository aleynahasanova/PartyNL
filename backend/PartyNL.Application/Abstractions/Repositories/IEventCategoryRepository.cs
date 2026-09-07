using PartyNL.Domain.Entities;

namespace PartyNL.Application.Abstractions.Repositories;

public interface IEventCategoryRepository
{
	Task<EventCategory?> GetByIdAsync(Guid eventId, Guid categoryId);

	Task<IEnumerable<EventCategory>> GetAllAsync();

	Task AddAsync(EventCategory eventCategory);

	Task UpdateAsync(EventCategory eventCategory);

	Task DeleteAsync(EventCategory eventCategory);
}
