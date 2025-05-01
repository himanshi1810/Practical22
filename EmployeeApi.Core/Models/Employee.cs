namespace EmployeeApi.Core.Models
{
    public class Employee
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string DepartmentId { get; set; } 
        public string EmailId { get; set; }
        public DateTime JoiningDate { get; set; } = DateTime.UtcNow;
        public bool Status { get; set; } = true;
    }
}
