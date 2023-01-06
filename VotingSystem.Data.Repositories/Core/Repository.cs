using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VotingSystem.Data.Abstraction;
using VotingSystem.EntityFramework;

namespace VotingSystem.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly MainDatabaseContext _context;

        public Repository(MainDatabaseContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public T? Find(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public T? FirstOrDefault(Expression<Func<T, bool>> whereCondition)
        {
            return _context.Set<T>().Where(whereCondition).FirstOrDefault();
        }

        public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> whereCondition)
        {
            return await _context.Set<T>().Where(whereCondition).FirstOrDefaultAsync();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public T? GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }
        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
