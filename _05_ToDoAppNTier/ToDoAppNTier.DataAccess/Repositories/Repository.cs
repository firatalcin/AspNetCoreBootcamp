using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ToDoAppNTier.DataAccess.Contexts;
using ToDoAppNTier.DataAccess.Interfaces;
using ToDoAppNTier.Entities.Concrete;

namespace ToDoAppNTier.DataAccess.Repositories
{
    internal class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ToDoContext _context;

        public Repository(ToDoContext context)
        {
            _context = context;
        }

        public async Task Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null)
        {
            return filter == null ?
                await _context.Set<T>().AsNoTracking().ToListAsync() :
                await _context.Set<T>().Where(filter).AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByFilter(Expression<Func<T, bool>> filter, bool asNoTracking = false)
        {
            return 
                asNoTracking == true ? 
                await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(filter) :
                await _context.Set<T>().FirstOrDefaultAsync(filter);
        }

        public async Task<T> GetById(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public IQueryable<T> GetQuery()
        {
            return _context.Set<T>().AsQueryable(); 
        }

        public void Remove(object id)
        {
            var deletedEntity = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(deletedEntity);
        }

        public void Update(T entity)
        {
            var updatedEntity = _context.Set<T>().Find(entity.Id);
            _context.Entry(updatedEntity).CurrentValues.SetValues(entity);
            //_context.Set<T>().Update(entity);
        }

       
    }
}
