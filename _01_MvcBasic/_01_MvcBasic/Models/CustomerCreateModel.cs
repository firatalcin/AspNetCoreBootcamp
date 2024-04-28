using System.ComponentModel.DataAnnotations;

namespace _01_MvcBasic.Models
{
    public class CustomerCreateModel
    {
        [Required(ErrorMessage = "Ad alanı boş geçilemez")]
        [MaxLength(30, ErrorMessage = "Ad alanı en fazla 30 karakter olabilir.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Soyad alanı boş geçilemez")]
        public string LastName { get; set; }
        [Range(18, 40, ErrorMessage = "18-40 yaş aralığında olmalıdır.")]
        public int Age { get; set; }
    }
}
