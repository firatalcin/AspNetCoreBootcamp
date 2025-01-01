using BlogApp.Web.Enums;

namespace BlogApp.Web.Entities;

public class Tag
{
    public int Id { get; set; }
    public string? Text { get; set; }
    public string? Url { get; set; }
    public TagColors? Color { get; set; }
    public List<Post> Posts { get; set; }   
}