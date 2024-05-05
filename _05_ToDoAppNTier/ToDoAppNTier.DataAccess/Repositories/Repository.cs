using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ToDoAppNTier.DataAccess.Context;
using ToDoAppNTier.DataAccess.Interfaces;
using ToDoAppNTier.Entities.Concrete;

namespace ToDoAppNTier.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ToDoContext _toDoContext;

        public Repository(ToDoContext toDoContext)
        {
            _toDoContext = toDoContext;
        }

        public async Task Create(T entity)
        {
            await _toDoContext.Set<T>().AddAsync(entity);
        }

        public async Task<List<T>> GetAll()
        {
            return await _toDoContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByFilter(Expression<Func<T, bool>> filter, bool asNoTracking = false)
        {
            return asNoTracking ? await _toDoContext.Set<T>().SingleOrDefaultAsync(filter) : await _toDoContext.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter);
        }

        public async Task<T> Find(object id)
        {
            return await _toDoContext.Set<T>().FindAsync(id);
        }

        public IQueryable<T> GetQuery()
        {
            return _toDoContext.Set<T>().AsQueryable();
        }

        public void Remove(T entity)
        {
            _toDoContext.Set<T>().Remove(entity);
        }

        public void Update(T entity, T unchanged)
        {
            _toDoContext.Entry(unchanged).CurrentValues.SetValues(entity);
        }
    }
}
