using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoAppNTier.DataAccess.Interfaces;
using ToDoAppNTier.Entities.Concrete;

namespace ToDoAppNTier.DataAccess.UnitOfWork
{
    public interface IUow
    {
        IRepository<T> GetRepository<T>() where T : BaseEntity;
        Task SaveChangesAsync();
        void SaveChanges();
    }
}
