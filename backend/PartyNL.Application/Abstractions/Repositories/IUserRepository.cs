using PartyNL.Domain.Entities;

namespace PartyNL.Application.Abstractions.Repositories;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid id);

    Task<User?> GetByEmailAsync(string email);

    Task<IEnumerable<User>> GetAllAsync();

    Task AddAsync(User user);

    Task UpdateAsync(User user);

    Task DeleteAsync(User user);
}