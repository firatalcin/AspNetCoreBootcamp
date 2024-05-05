using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoAppNTier.DataAccess.Context;
using ToDoAppNTier.DataAccess.Interfaces;
using ToDoAppNTier.DataAccess.Repositories;
using ToDoAppNTier.Entities.Concrete;

namespace ToDoAppNTier.DataAccess.UnitOfWork
{
    public class Uow : IUow
    {
        private readonly ToDoContext _context;

        public Uow(ToDoContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new Repository<T>(_context);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
