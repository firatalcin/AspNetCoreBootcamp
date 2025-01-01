using Microsoft.AspNetCore.Identity;

namespace IdentityApp.Web.Models;

public class AppUser : IdentityUser
{
    public string FullName { get; set; }
}