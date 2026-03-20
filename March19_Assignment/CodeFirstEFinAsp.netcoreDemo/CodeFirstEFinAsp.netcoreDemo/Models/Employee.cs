using System.ComponentModel.DataAnnotations;

namespace CodeFirstEFinAsp.netcoreDemo.Models
{
    public class Employee
    {
        public int Id { set; get; }

        [Required(ErrorMessage ="Please enter your first name")]
        public string? FirstName { set; get; }

        [Required(ErrorMessage ="Please enter your last name")]
        public string? LastName { set; get; }

        [Required(ErrorMessage ="Please enter your email")]
        [EmailAddress(ErrorMessage ="Enter valid email")]
        public string? Email { set; get; }

        [Required(ErrorMessage ="Enter your age")]
        [Range(0,100, ErrorMessage ="Please enter age between 1 to 100 only")]
        public int Age { set; get; }
    }
}
