using EFCore.Data;

namespace EFCore.App.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime CreateDate { get; set; }
        public List<SaleHistory> SaleHistories { get; set; }
        public ProductDetail ProductDetail { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
    }
}
