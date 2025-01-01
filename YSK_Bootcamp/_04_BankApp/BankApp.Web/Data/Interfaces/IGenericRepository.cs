namespace BankApp.Web.Data.Interfaces
{
    public interface IGenericRepository<T> where T : class, new()
    {
        void Create(T entity);
        void Remove(T entity);
        List<T> GetAll();
        T GetById(int id);
        void Update(T entity);
        IQueryable<T> GetQueryable();
    }
}
