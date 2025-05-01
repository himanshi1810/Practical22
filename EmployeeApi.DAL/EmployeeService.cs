using EmployeeApi.Core.Models;
using EmployeeApi.Core.DTOs;
using EmployeeApi.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.DAL
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _context;
        private static EmployeeService? _instance;
        private static readonly object _lock = new();

        private EmployeeService(AppDbContext context)
        {
            _context = context;
        }

        public static EmployeeService GetInstance(AppDbContext context)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new EmployeeService(context); 
                }
            }
            return _instance;
        }

        public async Task<Employee> CreateAsync(EmployeeCreateDTO dto)
        {
            var emp = new Employee
            {
                Name = dto.Name,
                Salary = dto.Salary,
                DepartmentId = dto.DepartmentId,
                EmailId = dto.EmailId,
                Status = true,
                JoiningDate = DateTime.UtcNow
            };
            _context.Employees.Add(emp);
            await _context.SaveChangesAsync();
            return emp;
        }

        public async Task<Employee> UpdateAsync(EmployeeUpdateDTO dto)
        {
            var emp = await _context.Employees.FindAsync(dto.Id);
            if (emp == null) throw new Exception("Employee not found");

            emp.Name = dto.Name;
            emp.Salary = dto.Salary;
            emp.DepartmentId = dto.DepartmentId;
            emp.EmailId = dto.EmailId;
            await _context.SaveChangesAsync();
            return emp;
        }

        public async Task<bool> DeactivateAsync(int id)
        {
            var emp = await _context.Employees.FindAsync(id);
            if (emp == null) return false;
            emp.Status = false;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }
    }
}
