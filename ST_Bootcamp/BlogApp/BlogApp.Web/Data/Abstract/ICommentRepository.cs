using BlogApp.Web.Entities;

namespace BlogApp.Web.Data.Abstract;

public interface ICommentRepository
{
    IQueryable<Comment> Comments { get; }
    void CreateComment(Comment comment);
}