using IdentityApp.Web.Models;
using IdentityApp.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApp.Web.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<AppRole> _roleManager;
    private readonly SignInManager<AppUser> _signInManager;
    
    // GET
    public AccountController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _signInManager = signInManager;
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if(ModelState.IsValid)
        {
            var user  = await _userManager.FindByEmailAsync(model.Email);

            if(user != null)
            {
                await _signInManager.SignOutAsync();

                if(!await _userManager.IsEmailConfirmedAsync(user))
                {
                    ModelState.AddModelError("", "Hesabınızı onaylayınız.");
                    return View(model);
                }

                var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe,true);

                if(result.Succeeded)
                {
                    await _userManager.ResetAccessFailedCountAsync(user);
                    await _userManager.SetLockoutEndDateAsync(user, null);

                    return RedirectToAction("Index","Home");
                }
                else if(result.IsLockedOut)
                {
                    var lockoutDate = await _userManager.GetLockoutEndDateAsync(user);
                    var timeLeft = lockoutDate.Value - DateTime.UtcNow;
                    ModelState.AddModelError("", $"Hesabınız kitlendi, Lütfen {timeLeft.Minutes} dakika sonra deneyiniz");
                }
                else
                {
                    ModelState.AddModelError("", "parolanız hatalı");
                }
            }
            else
            {
                ModelState.AddModelError("", "bu email adresiyle bir hesap bulunamadı");
            }
        }
        return View(model);
    }
}