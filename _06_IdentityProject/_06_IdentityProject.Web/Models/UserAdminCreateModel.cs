using System.ComponentModel.DataAnnotations;

namespace _06_IdentityProject.Web.Models
{
    public class UserAdminCreateModel
    {
        [Required(ErrorMessage = "Kullanıcı adı gereklidir")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Email adresi gereklidir")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Cinsiyet gereklidir")]
        public string Gender { get; set; }
    }
}
