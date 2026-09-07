using Microsoft.EntityFrameworkCore;
using PartyNL.Application.Abstractions.Repositories;
using PartyNL.Domain.Entities;
using PartyNL.Persistence.Context;

namespace PartyNL.Persistence.Repositories;

public class CategoryRepository : ICategoryRepository
{
	private readonly PartyNLDbContext _context;

	public CategoryRepository(PartyNLDbContext context)
	{
		_context = context;
	}

	public Task<Category?> GetByIdAsync(Guid id)
	{
		return _context.Categories.AsNoTracking().FirstOrDefaultAsync(category => category.Id == id);
	}

	public async Task<IEnumerable<Category>> GetAllAsync()
	{
		return await _context.Categories.AsNoTracking().ToListAsync();
	}

	public async Task AddAsync(Category category)
	{
		await _context.Categories.AddAsync(category);
	}

	public Task UpdateAsync(Category category)
	{
		_context.Categories.Update(category);
		return Task.CompletedTask;
	}

	public Task DeleteAsync(Category category)
	{
		_context.Categories.Remove(category);
		return Task.CompletedTask;
	}
}
