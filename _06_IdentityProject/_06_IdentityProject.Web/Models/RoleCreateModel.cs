using System.ComponentModel.DataAnnotations;

namespace _06_IdentityProject.Web.Models
{
    public class RoleCreateModel
    {
        [Required(ErrorMessage = "Rol ismi gereklidir")]
        public string Name { get; set; }
    }
}
