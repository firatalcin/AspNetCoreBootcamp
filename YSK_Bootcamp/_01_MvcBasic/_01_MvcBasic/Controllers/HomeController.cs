using _01_MvcBasic.Filters;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcBasic.Models;

namespace _01_MvcBasic.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var customers = CustomerContext.Customers;
            return View(customers);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidFirstName]
        public IActionResult Add(Customer customer)
        {
            var lastCustomer = CustomerContext.Customers.Last();

            if (ModelState.IsValid)
            {
                var id = lastCustomer.Id + 1;

                CustomerContext.Customers.Add(
                    new Customer
                    {
                        Id = id,
                        FirstName = customer.FirstName,
                        LastName = customer.LastName,
                        Age = customer.Age
                    });

                return RedirectToAction("Index");
            }
           return View();
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {

            var customer = CustomerContext.Customers.Find(x => x.Id == id);
            CustomerContext.Customers.Remove(customer);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var customer = CustomerContext.Customers.FirstOrDefault(x => x.Id == id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult Update(Customer customerModel)
        {
            var customer = CustomerContext.Customers.FirstOrDefault(x => x.Id == customerModel.Id);

            customer.FirstName = customerModel.FirstName;
            customer.LastName = customerModel.LastName;
            customer.Age = customerModel.Age;



            return RedirectToAction("Index");

        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Status(int? code)
        {
            return View();
        }

        public IActionResult Error()
        {
            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            var logFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "logs");

            var logFileName = DateTime.Now.ToString();

            logFileName = logFileName.Replace(" ", "_");
            logFileName = logFileName.Replace(":", "-");
            logFileName = logFileName.Replace("/", "-");

            logFileName += ".txt";

            var logFilePath = Path.Combine(logFolderPath,logFileName);

            DirectoryInfo directoryInfo = new DirectoryInfo(logFolderPath);

            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }

            FileInfo logFileInfo = new FileInfo(logFilePath);
            var writer = logFileInfo.CreateText();
            writer.WriteLine("Hatanýn gerçekleþtiði yer: " + exceptionHandlerPathFeature.Path);

            writer.WriteLine("Hata mesajý: " + exceptionHandlerPathFeature.Error.Message);

            writer.Close();

            return View();
        }

        public IActionResult Hata() 
        { 
            throw new Exception("Patladýk");
        }


    }
}
