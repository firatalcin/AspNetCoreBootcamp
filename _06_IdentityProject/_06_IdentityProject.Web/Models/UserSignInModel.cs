using System.ComponentModel.DataAnnotations;

namespace _06_IdentityProject.Web.Models
{
    public class UserSignInModel
    {
        [Required(ErrorMessage = "Kullanıcı adı gereklidir.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Parola gereklidir.")]
        public string Password { get; set; }
    }
}
