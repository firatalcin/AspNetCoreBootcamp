using _06_IdentityProject.Web.Entities;
using _06_IdentityProject.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace _06_IdentityProject.Web.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var list = _roleManager.Roles.ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            return View(new AppRole());
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleCreateModel model)
        {
            if (ModelState.IsValid) 
            {
                var result = await _roleManager.CreateAsync(new AppRole
                {
                    Name = model.Name,
                    CreatedDate = DateTime.Now
                });

                if (result.Succeeded) 
                {
                    return RedirectToAction("Index");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View(model);
        }
    }
}
