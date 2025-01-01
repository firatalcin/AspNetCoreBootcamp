using _01_MvcBasic.Models;
using Microsoft.AspNetCore.Mvc;

namespace _01_MvcBasic.ViewComponents
{
    public class NewsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string color="default")
        {
            var list = NewsContext.news;
            if(color == "default")
            {
                return View(list);
            }
            else if(color == "red")
            {
                return View("Red", list);
            }
            else
            {
                return View("Blue", list);
            }
        }
    }
}
