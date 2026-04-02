using System.ComponentModel.DataAnnotations;

namespace WebApplicationAPI.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Department { get; set; }

        public double Salary { get; set; }
    }
}
