using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class UserInfo
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ad alanı boş bırakılamaz")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Mail alanı boş bırakılamaz")]
        [EmailAddress]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Telefon alanı boş bırakılamaz")]
        public string? Phone { get; set; }
        [Required]
        public bool WillAttend { get; set; }
    }
}
