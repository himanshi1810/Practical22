using EmployeeApi.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.Core.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
  
