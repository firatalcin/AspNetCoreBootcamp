using EFCore.Dependency.Models;
using EFCore.Dependency.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EFCore.Dependency.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly ITransientService _transientService;
        private readonly IScopedService _scopedService;
        private readonly ISingletonService _singletonService;

        public HomeController(IProductService productService, ITransientService transientService, IScopedService scopedService, ISingletonService singletonService)
        {
            _productService = productService;
            _transientService = transientService;
            _scopedService = scopedService;
            _singletonService = singletonService;
        }

        public IActionResult Index()
        {
            ViewBag.Singleton = _singletonService.GuidId;
            ViewBag.Transient = _transientService.GuidId;
            ViewBag.Scoped = _scopedService.GuidId;
            return View();
        }
    }

    public interface IProductService
    {
        int GetTotal();
    }

    public class ProductManager : IProductService
    {
        public int GetTotal()
        {
            return 40;
        }
    }
}

