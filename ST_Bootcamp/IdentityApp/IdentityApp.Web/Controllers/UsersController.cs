using IdentityApp.Web.Models;
using IdentityApp.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IdentityApp.Web.Controllers;

public class UsersController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<AppRole> _roleManager;

    public UsersController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
    }
    


    // GET
    public IActionResult Index()
    {
        return View(_userManager.Users.ToList());
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new AppUser()
            {
                UserName = model.UserName,
                Email = model.Email,
                FullName = model.FullName,
            };
            
            IdentityResult result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            foreach (var err in result.Errors)
            {
                ModelState.AddModelError(string.Empty, err.Description);
            }
        }
        
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(string id)
    {
        if (id == null)
        {
            return RedirectToAction("Index");
        }
        
        var user = await _userManager.FindByIdAsync(id);

        if (user != null)
        {
            ViewBag.Roles = await _roleManager.Roles.Select(x => x.Name).ToListAsync();
            
            return View(new EditViewModel()
            {
                Id = user.Id,
                Email = user.Email,
                FullName = user.FullName,
                SelectedRoles = await _userManager.GetRolesAsync(user)
            });
        }
        else
        {
            return RedirectToAction("Index");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Edit(string id, EditViewModel model)
    {
        if (id != model.Id)
        {
            return RedirectToAction("Index");
        }

        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByIdAsync(model.Id);

            if (user != null)
            {
                user.Email = model.Email;
                user.FullName = model.FullName;
                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded && !string.IsNullOrEmpty(model.Password))
                {
                    await _userManager.RemovePasswordAsync(user);
                    await _userManager.AddPasswordAsync(user, model.Password);
                    
                    return RedirectToAction("Index");
                }
                else if (result.Succeeded)
                {
                    await _userManager.RemoveFromRolesAsync(user, await _userManager.GetRolesAsync(user));
                    if(model.SelectedRoles != null)
                    {
                        await _userManager.AddToRolesAsync(user, model.SelectedRoles);
                    }
                    
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, item.Description);
                    }
                }
            }
        }
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(string id)
    {
        var user = await _userManager.FindByIdAsync(id);

        if (user != null)
        {
            var result = await _userManager.DeleteAsync(user);
        }
        
        return RedirectToAction("Index");
    }
}