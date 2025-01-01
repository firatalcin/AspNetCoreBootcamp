using BlogApp.Web.Entities;

namespace BlogApp.Web.Data.Abstract;

public interface ITagRepository
{
    IQueryable<Tag> Tags { get; }
    void CreateTag(Tag tag);
}