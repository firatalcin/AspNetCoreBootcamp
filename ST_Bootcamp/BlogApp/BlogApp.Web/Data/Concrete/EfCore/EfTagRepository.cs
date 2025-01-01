using BlogApp.Web.Data.Abstract;
using BlogApp.Web.Entities;

namespace BlogApp.Web.Data.Concrete.EfCore;

public class EfTagRepository : ITagRepository
{
    private readonly AppDbContext _context;

    public EfTagRepository(AppDbContext context)
    {
        _context = context;
    }

    public IQueryable<Tag> Tags => _context.Tags;
    public void CreateTag(Tag tag)
    {
        _context.Tags.Add(tag);
        _context.SaveChanges(); 
    }
}