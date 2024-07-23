using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ToDoAppNTier.DataAccess.Interfaces
{
    public interface IRepository<T> where T : class, new()
    {
        Task<List<T>> GetAll(Expression<Func<T, bool>> filter=null);
        Task<T> GetById(object id);
        Task<T> GetByFilter(Expression<Func<T, bool>> filter, bool asNoTracking = false);
        Task Create(T entity);
        void Update(T entity);
        void Remove(T entity);
        IQueryable<T> GetQuery();
    }
}
