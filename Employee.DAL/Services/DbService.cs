using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.DAL.Services
{
    public sealed class DbService
    {
        private static readonly Lazy<DbService> _instance = new Lazy<DbService>(() => new DbService());
        private readonly string _connectionString;

        public DbService()
        {
            _connectionString = "Server=SF-CPU-0226\\SQLEXPRESS;Database=Practical_22;Trusted_Connection=True;Encrypt=False;";
        }

        public static DbService Instance => _instance.Value;

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
