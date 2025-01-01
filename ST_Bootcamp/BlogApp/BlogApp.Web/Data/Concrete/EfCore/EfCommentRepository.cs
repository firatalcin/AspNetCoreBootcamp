using BlogApp.Web.Data.Abstract;
using BlogApp.Web.Entities;

namespace BlogApp.Web.Data.Concrete.EfCore;

public class EfCommentRepository : ICommentRepository
{
    private readonly AppDbContext _context;

    public EfCommentRepository(AppDbContext context)
    {
        _context = context;
    }

    public IQueryable<Comment> Comments => _context.Comments;
    public void CreateComment(Comment comment)
    {
        _context.Comments.Add(comment); 
        _context.SaveChanges();
    }
}