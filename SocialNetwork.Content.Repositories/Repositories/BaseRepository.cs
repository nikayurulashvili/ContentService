using Microsoft.EntityFrameworkCore;

using SocialNetwork.Content.Repositories.Database;
using SocialNetwork.Content.Repositories.Interfaces;

namespace SocialNetwork.Content.Repositories.Repositories;

public class BaseRepository<T> : IBaseRepository<T>
    where T : class
{
    protected readonly ContentDbContext _context;

    protected readonly DbSet<T> _dbSet;

    public BaseRepository(ContentDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public  virtual async Task<T?> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }
}