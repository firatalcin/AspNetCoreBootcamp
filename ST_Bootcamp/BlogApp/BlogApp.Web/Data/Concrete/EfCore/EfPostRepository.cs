using BlogApp.Web.Data.Abstract;
using BlogApp.Web.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Web.Data.Concrete.EfCore;

public class EfPostRepository : IPostRepository
{
    private readonly AppDbContext _context;

    public EfPostRepository(AppDbContext context)
    {
        _context = context;
    }

    public IQueryable<Post> Posts => _context.Posts;
    
    public void CreatePost(Post post)
    {
        _context.Posts.Add(post);
        _context.SaveChanges();
    }

    public void EditPost(Post post)
    {
        var entity = _context.Posts.FirstOrDefault(i => i.Id == post.Id);

        if(entity != null)
        {
            entity.Title = post.Title;
            entity.Description = post.Description;
            entity.Content = post.Content;
            entity.Url = post.Url;
            entity.IsActive = post.IsActive;

            _context.SaveChanges();
        }
    }

    public void EditPost(Post post, int[] tagIds)
    {
        var entity = _context.Posts.Include(i=>i.Tags).FirstOrDefault(i => i.Id == post.Id);

        if(entity != null)
        {
            entity.Title = post.Title;
            entity.Description = post.Description;
            entity.Content = post.Content;
            entity.Url = post.Url;
            entity.IsActive = post.IsActive;

            entity.Tags = _context.Tags.Where(tag => tagIds.Contains(tag.Id)).ToList();

            _context.SaveChanges();
        }
    }
}