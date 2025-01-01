using Microsoft.AspNetCore.Mvc;

namespace _01_MvcBasic.Controllers
{
    public class SessionController : Controller
    {
        public IActionResult Index()
        {
            SetSession();
            ViewBag.Session = GetSession();
            return View();
        }

        private void SetSession()
        {
            HttpContext.Session.SetString("Course", "Asp Net Core");
        }

        private string GetSession()
        {
            return HttpContext.Session.GetString("Course");
        }
    }
}
