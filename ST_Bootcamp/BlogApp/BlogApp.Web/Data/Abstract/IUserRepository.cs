using BlogApp.Web.Entities;

namespace BlogApp.Web.Data.Abstract;

public interface IUserRepository
{
    IQueryable<User> Users { get; }
    void CreateUser(User User);
}