using PartyNL.Domain.Entities;

namespace PartyNL.Application.Abstractions.Repositories;

public interface ICategoryRepository
{
    Task<Category?> GetByIdAsync(Guid id);

    Task<IEnumerable<Category>> GetAllAsync();

    Task AddAsync(Category category);

    Task UpdateAsync(Category category);

    Task DeleteAsync(Category category);
}