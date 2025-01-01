using BlogApp.Web.Data.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Web.ViewComponents;

public class TagsMenu : ViewComponent
{
    private readonly ITagRepository _tagRepository;

    public TagsMenu(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View(await _tagRepository.Tags.ToListAsync());
    }
}