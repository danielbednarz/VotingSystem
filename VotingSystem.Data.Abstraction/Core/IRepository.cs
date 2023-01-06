using System.Linq.Expressions;

namespace VotingSystem.Data.Abstraction
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        T? GetById(int id);
        Task<List<T>> GetAllAsync();
        List<T> GetAll();
        T? Find(int id);
        T? FirstOrDefault(Expression<Func<T, bool>> whereCondition);
        Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> whereCondition);
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        bool Save();
        Task<bool> SaveAsync();
    }
}
