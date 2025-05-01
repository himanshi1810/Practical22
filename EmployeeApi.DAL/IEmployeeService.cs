using EmployeeWebApi.Models;
using EmployeeWebApi.DTOs;

namespace EmployeeApi.DAL
{
    public interface IEmployeeService
    {
        Task<Employee> CreateAsync(EmployeeCreateDTO dto);
        Task<Employee> UpdateAsync(EmployeeUpdateDTO dto);
        Task<bool> DeactivateAsync(int id);
        Task<Employee?> GetByIdAsync(int id);
        Task<List<Employee>> GetAllAsync();
    }
}
