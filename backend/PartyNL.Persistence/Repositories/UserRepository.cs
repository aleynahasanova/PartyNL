using Microsoft.EntityFrameworkCore;
using PartyNL.Application.Abstractions.Repositories;
using PartyNL.Domain.Entities;
using PartyNL.Persistence.Context;

namespace PartyNL.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly PartyNLDbContext _context;

    public UserRepository(PartyNLDbContext context)
    {
        _context = context;
    }

    public Task<User?> GetByIdAsync(Guid id)
    {
        return _context.Users.FirstOrDefaultAsync(user => user.Id == id);
    }

    public Task<User?> GetByEmailAsync(string email)
    {
        return _context.Users.FirstOrDefaultAsync(user => user.Email == email);
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public Task UpdateAsync(User user)
    {
        _context.Users.Update(user);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(User user)
    {
        _context.Users.Remove(user);
        return Task.CompletedTask;
    }
}