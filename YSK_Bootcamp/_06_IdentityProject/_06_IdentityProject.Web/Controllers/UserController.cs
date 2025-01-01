using _06_IdentityProject.Web.Contexts;
using _06_IdentityProject.Web.Entities;
using _06_IdentityProject.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace _06_IdentityProject.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public UserController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userManager.GetUsersInRoleAsync("Member");
            return View(users);
        }

        public IActionResult Create()
        {
            return View(new UserAdminCreateModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserAdminCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    Email = model.Email,
                    Gender = model.Gender,
                    UserName = model.Username
                };

                var result = await _userManager.CreateAsync(user, model.Username + "123");

                if (result.Succeeded) 
                {
                    var memberRole = await _roleManager.FindByNameAsync("Member");
                    if(memberRole == null)
                    {
                        await _roleManager.CreateAsync(new AppRole
                        {
                            Name = "Member",
                            CreatedDate = DateTime.Now,
                        });
                    }

                    await _userManager.AddToRoleAsync(user, "Member");
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
