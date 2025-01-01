using BlogApp.Web.Entities;

namespace BlogApp.Web.Models;

public class PostsViewModel
{
    public List<Post> Posts { get; set; } = new();
}