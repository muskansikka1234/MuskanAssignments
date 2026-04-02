using Microsoft.AspNetCore.Mvc;
using MVCExampleDemo.Models;
using System.Diagnostics;

namespace MVCExampleDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public string sampledemo1()
        {
            return "Muskan Sikka";
        }

        public string sampledemo2(int age, string name)
        {
            return "The name " + name + " and having age " + age;
        }

        public IActionResult sampledemo3()
        {
            int age = 34;
            string name = "Muskan Sikka";
            ViewBag.Name = name;
            ViewBag.Age = age;
            ViewData["Message"] = "Welcome to Asp.net core learning";
            ViewData["Year"] = DateTime.Now.Year;
            return View();
        }

        Employee obj = new Employee()
        {
            EmployeeID = 101,
            EmpName = "Ravi",
            salary = 34000,
        };

        List<Employee> emplist = new List<Employee>()
        {
            new Employee{EmployeeID=101, EmpName="Muskan", salary=50000, ImageUrl="/images/photo.jpg" },
            new Employee{EmployeeID=102, EmpName="Mahek", salary=30000, ImageUrl="/images/photo2.jpg" },
            new Employee{EmployeeID=103, EmpName="Muskan2", salary=100000, ImageUrl="/images/Professional_photo.png" },
        };

        public IActionResult collectionOfObjectPassing()
        {
            return View(emplist);
        }

        public IActionResult singleobjpassing()
        {
            return View(obj);
        }

        public IActionResult display()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
