using WebApplicationAPI.Models;

namespace WebApplicationAPI.Services
{
    public interface IEmployee
    {
        Task<List<Employee>> GetAllEmployeesAsync();
        Task<Employee> AddEmployeeAsync(Employee emp);
        Task<bool> DeleteEmployeeAsync(int id);
    }
}
