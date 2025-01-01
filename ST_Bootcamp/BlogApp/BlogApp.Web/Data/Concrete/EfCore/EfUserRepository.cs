using BlogApp.Web.Data.Abstract;
using BlogApp.Web.Entities;

namespace BlogApp.Web.Data.Concrete.EfCore;

public class EfUserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public EfUserRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public IQueryable<User> Users => _context.Users;
    public void CreateUser(User User)
    {
        _context.Users.Add(User);   
        _context.SaveChanges();
    }
}