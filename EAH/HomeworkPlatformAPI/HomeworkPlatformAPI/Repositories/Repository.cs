using HomeworkPlatformAPI.Data;
using HomeworkPlatformAPI.Interfaces;
using HomeworkPlatformAPI.Models.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HomeworkPlatformAPI.Repositories
{
    public class Repository<T> : IRepository<T>
        where T : BaseClass
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T item)
        {
            await _dbSet
                .AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var item = await GetByIdAsync(id);
            if (item != null)
            {
                _dbSet.Remove(item);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException($"Item does not exist! (ID: {id}");
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate)
                .ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _dbSet.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
