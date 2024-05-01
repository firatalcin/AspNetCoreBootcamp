using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.Data
{
    //[Table(name: "Category", Schema = "c")]
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [Column("category_name", TypeName = "nvarchar(100)")]
        public string Name { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
    }
}
