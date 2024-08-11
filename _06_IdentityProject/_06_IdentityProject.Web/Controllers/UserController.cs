using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _06_IdentityProject.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
