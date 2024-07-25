using HomeworkPlatformAPI.Models.Abstractions;
using System.Linq.Expressions;

namespace HomeworkPlatformAPI.Interfaces
{
    public interface IRepository<T>
        where T : BaseClass
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteByIdAsync(int id);
    }
}
