using EFCore.App.Data.Contexts;
using EFCore.App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EFCore.App.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            AppDbContext context = new AppDbContext();

            //context.Products.Add(new Product
            //{
            //    Name = "Telefon",
            //    Price = 15000
            //});

            //var updatedProduct = context.Products.FirstOrDefault();
            //updatedProduct.Price = 10000;
            //context.Products.Update(updatedProduct);

            var deletedProduct = context.Products.Find(1);
            context.Products.Remove(deletedProduct);

            context.SaveChanges();

            return View();
        }

      
    }
}
