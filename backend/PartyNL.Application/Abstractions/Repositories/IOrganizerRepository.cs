using PartyNL.Domain.Entities;

namespace PartyNL.Application.Abstractions.Repositories;

public interface IOrganizerRepository
{
	Task<Organizer?> GetByIdAsync(Guid id);

	Task<IEnumerable<Organizer>> GetAllAsync();

	Task AddAsync(Organizer organizer);

	Task UpdateAsync(Organizer organizer);

	Task DeleteAsync(Organizer organizer);
}
