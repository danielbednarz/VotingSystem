using System.Linq.Expressions;

namespace VotingSystem.Data.Abstraction
{
    public interface IRepository<T> where T : class
    {
        T? GetById(int id);
        Task<List<T>> GetAllAsync();
        List<T> GetAll();
        T? Find(int id);
        T? FirstOrDefault(Expression<Func<T, bool>> whereCondition);
        Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> whereCondition);
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        int Save();
        Task<int> SaveAsync();
    }
}
