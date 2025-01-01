using Microsoft.AspNetCore.Identity;

namespace ProductApi.Models;

public class AppUser : IdentityUser<int>
{
    public string FullName { get; set; }
    public DateTime CreateDate { get; set; }
}