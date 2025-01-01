using Microsoft.AspNetCore.Identity;

namespace _06_IdentityProject.Web.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string ImagePath { get; set; }
        public string Gender { get; set; }
    }
}
