using System.Security.Claims;
using BlogApp.Web.Data.Abstract;
using BlogApp.Web.Entities;
using BlogApp.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Web.Controllers;

public class UsersController : Controller
{
    private readonly IUserRepository _userRepository;

    public UsersController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    // GET
    public IActionResult Login()
    {
        if (User.Identity!.IsAuthenticated)
        {
            return RedirectToAction("Index", "Home");
        }
        
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var isUser =
                _userRepository.Users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);

            if (isUser != null)
            {
                var userClaims = new List<Claim>();
                userClaims.Add(new Claim(ClaimTypes.NameIdentifier, isUser.Id.ToString()));
                userClaims.Add(new Claim(ClaimTypes.Name, isUser.UserName ?? ""));
                userClaims.Add(new Claim(ClaimTypes.Email, isUser.Email ?? ""));
                userClaims.Add(new Claim(ClaimTypes.UserData, isUser.Image ?? ""));

                if (isUser.Email == "info@sadikturan.com")
                {
                    userClaims.Add(new Claim(ClaimTypes.Role, "Admin"));
                }

                var claimsIdentity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                };

                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), authProperties);

                return RedirectToAction("Index", "Posts");
            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış");
            }
        }

        return View(model);
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Login", "Users");
    }
    
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if(ModelState.IsValid)
        {
            var user = await _userRepository.Users.FirstOrDefaultAsync(x => x.UserName == model.UserName || x.Email == model.Email);
            if(user == null)
            {
                _userRepository.CreateUser(new User {
                    UserName  = model.UserName,
                    Name = model.Name,
                    Email = model.Email,
                    Password = model.Password,
                    Image = "avatar.jpg"
                });
                return RedirectToAction("Login");
            }
            else
            {
                ModelState.AddModelError("", "Username ya da Email kullanımda.");
            }
        }
        return View(model);
    }
    
    public IActionResult Profile(string  username)
    {
        if(string.IsNullOrEmpty(username))
        {
            return NotFound();
        }
        var user = _userRepository
            .Users
            .Include(x => x.Posts)
            .Include(x => x.Comments)
            .ThenInclude(x => x.Post)
            .FirstOrDefault(x => x.UserName == username);

        if(user == null)
        {
            return NotFound();
        }
        return View(user);
    }

}