namespace EmployeeApi.Core.DTOs
{
    public class EmployeeCreateDTO
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string DepartmentId { get; set; }
        public string EmailId { get; set; }
    }
}
