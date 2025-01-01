using System.ComponentModel.DataAnnotations;
using WebUI.Data;

namespace WebUI.Models
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public int TeacherId { get; set; }
        public ICollection<Register> Registers { get; set; }
    }
}
