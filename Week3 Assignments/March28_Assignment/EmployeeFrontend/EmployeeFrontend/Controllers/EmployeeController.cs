using EmployeeFrontend.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace EmployeeFrontend.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly string apiUrl = "https://localhost:7155/api/Emp";

        public async Task<IActionResult> Index()
        {
            List<Employee> employees = new List<Employee>();

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    employees = JsonConvert.DeserializeObject<List<Employee>>(data);
                }
            }

            return View(employees);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee emp)
        {
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(emp);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                await client.PostAsync(apiUrl, content);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            using (var client = new HttpClient())
            {
                await client.DeleteAsync($"{apiUrl}/{id}");
            }

            return RedirectToAction("Index");
        }
    }
}
