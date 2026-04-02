using Microsoft.EntityFrameworkCore;
using WebApiInAsp.netcoreMvcDemo.Models;

namespace WebApiInAsp.netcoreMvcDemo
{
    public class EmployeeService : IEmployee
    {
        private readonly EmpContext _context;
        private readonly IWebHostEnvironment _env;

        public EmployeeService(EmpContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<Employee> AddEmployeeAsync(Employee employee, IFormFile image)
        {
            if(image !=  null && image.Length > 0)
            {
                var imageName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                var imagePath = Path.Combine(_env.WebRootPath, "uploads", imageName);
                Directory.CreateDirectory(Path.GetDirectoryName(imagePath)!);
                using var stream = new FileStream(imagePath, FileMode.Create);
                await image.CopyToAsync(stream);
                employee.ImagePath = "/uploads/" + imageName;
            }
            await _context.employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee?> DeleteEmployeeAsync(int id)
        {
            var employee = await _context.employees.FindAsync(id);
            if (employee == null) return null;
            _context.employees.Remove(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<List<Employee>> GetAllEmployeesAsync(int pageNumber, int pageSize)
        {

            return await _context.employees.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            return await _context.employees.FindAsync(id);
        }

        public async Task<Employee?> UpdateEmployeeAsync(Employee employee, IFormFile? image)
        {
            var exsistng = await _context.employees.FindAsync(employee.Id);
            if (exsistng == null)
            {
                return null;
            }
            exsistng.FirstName = employee.FirstName;
            exsistng.LastName = employee.LastName;
            exsistng.Email = employee.Email;
            exsistng.Age = employee.Age;

            if (image != null && image.Length > 0)
            {
                var imageName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                var imagePath = Path.Combine(_env.WebRootPath, "uploads", imageName);
                Directory.CreateDirectory(Path.GetDirectoryName(imagePath)!);
                using var stream = new FileStream(imagePath, FileMode.Create);
                await image.CopyToAsync(stream);
                employee.ImagePath = "/uploads/" + imageName;


            }

            await _context.SaveChangesAsync();
            return exsistng;
        }
    }
}
