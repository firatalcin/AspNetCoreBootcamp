using _06_IdentityProject.Web.Entities;
using _06_IdentityProject.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace _06_IdentityProject.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View(new UserCreateModel());
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserCreateModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser()
                {
                    Email = model.Email,
                    Gender = model.Gender,
                    UserName = model.Username,
                    ImagePath = ""
                };

                

                var identityResult = await _userManager.CreateAsync(appUser, model.Password);
                if (identityResult.Succeeded) 
                {
                    await _roleManager.CreateAsync(new AppRole
                    {
                        Name = "Admin",
                        CreatedDate = DateTime.Now,
                    });
                    await _userManager.AddToRoleAsync(appUser, "Admin");
                    return RedirectToAction("Index");
                }
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        public IActionResult SignIn()
        {
            return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserSignInModel model)
        {
            if (ModelState.IsValid)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, true);

                if (signInResult.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else if (signInResult.IsLockedOut)
                {

                }
                else if (signInResult.IsNotAllowed)
                {

                }
            }
            return View(model);
        }

        [Authorize]
        public IActionResult GetUserInfo()
        {
            var username = User.Identity.Name;
            var role = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value;
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
