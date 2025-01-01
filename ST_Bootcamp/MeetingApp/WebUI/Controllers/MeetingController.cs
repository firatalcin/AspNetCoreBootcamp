using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class MeetingController : Controller
    {
        [HttpGet]
        public IActionResult Apply()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Apply(UserInfo userInfo)
        {
            if (ModelState.IsValid)
            {
                Repository.CreateUser(userInfo);
                ViewBag.UserCount = Repository.Users().Where(x => x.WillAttend == true).Count();
                return View("Thanks", userInfo);
            }
            else
            {
                return View(userInfo);
            }

            
        }

        public IActionResult List()
        {
            var model = Repository.Users();
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = Repository.GetUserDetail(id);
            return View(model);
        }
    }
}
