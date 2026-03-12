namespace MVCExampleDemo.Models
{
    public class Employee
    {
        public int EmployeeID { set; get; }
        public string? EmpName { set; get; }
        public int salary { set; get; }

        public string? ImageUrl { set; get; }

        public int DeptID { get; set; }
        public Dept? Dept { get; set; }
    }
}
