using Microsoft.AspNetCore.Mvc;

namespace _01_MvcBasic.Controllers
{
    public class CookieController : Controller
    {
        public IActionResult Index()
        {
            SetCookie();
            ViewBag.Cookie = GetCookie();
            return View();
        }

        public void SetCookie()
        {
            HttpContext.Response.Cookies.Append("Course", "Asp Net Core", new Microsoft.AspNetCore.Http.CookieOptions
            {
                Expires = DateTime.Now.AddDays(10),
                HttpOnly = true,
                SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict
            });
        }

        public string GetCookie()
        {
            string cookieValue = string.Empty;
            HttpContext.Request.Cookies.TryGetValue("Course", out cookieValue);
            return cookieValue;
        }
    }
}
