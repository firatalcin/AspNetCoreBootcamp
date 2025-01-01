using Microsoft.AspNetCore.Identity;
using System;

namespace _06_IdentityProject.Web.Entities
{
    public class AppRole : IdentityRole<int>
    {
        public DateTime CreatedDate { get; set; }
    }
}
