using PartyNL.Domain.Entities;

namespace PartyNL.Application.Abstractions.Repositories;

public interface IAttendanceRepository
{
	Task<Attendance?> GetByIdAsync(Guid userId, Guid eventId);

	Task<IEnumerable<Attendance>> GetAllAsync();

	Task AddAsync(Attendance attendance);

	Task UpdateAsync(Attendance attendance);

	Task DeleteAsync(Attendance attendance);
}
