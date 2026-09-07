using Microsoft.EntityFrameworkCore;
using PartyNL.Application.Abstractions.Repositories;
using PartyNL.Domain.Entities;
using PartyNL.Persistence.Context;

namespace PartyNL.Persistence.Repositories;

public class AttendanceRepository : IAttendanceRepository
{
	private readonly PartyNLDbContext _context;

	public AttendanceRepository(PartyNLDbContext context)
	{
		_context = context;
	}

	public Task<Attendance?> GetByIdAsync(Guid userId, Guid eventId)
	{
		return _context.Attendances.AsNoTracking()
			.FirstOrDefaultAsync(attendance => attendance.UserId == userId && attendance.EventId == eventId);
	}

	public async Task<IEnumerable<Attendance>> GetAllAsync()
	{
		return await _context.Attendances.AsNoTracking().ToListAsync();
	}

	public async Task AddAsync(Attendance attendance)
	{
		await _context.Attendances.AddAsync(attendance);
	}

	public Task UpdateAsync(Attendance attendance)
	{
		_context.Attendances.Update(attendance);
		return Task.CompletedTask;
	}

	public Task DeleteAsync(Attendance attendance)
	{
		_context.Attendances.Remove(attendance);
		return Task.CompletedTask;
	}
}
