using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoAppNTier.DataAccess.Interfaces;

namespace ToDoAppNTier.DataAccess.UnitOfWork
{
    public interface IUow
    {
        IRepository<T> GetRepository<T>() where T : class, new();
        Task SaveChangesAsync();
        void SaveChanges();
    }
}
