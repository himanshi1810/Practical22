using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.DAL.Services
{
    public sealed class DbContext
    {
        private static readonly Lazy<DbContext> _instance = new Lazy<DbContext>(() => new DbContext());
        private readonly string _connectionString;

        public DbContext()
        {
            _connectionString = "Server=SF-CPU-0226\\SQLEXPRESS;Database=Practical_22;Trusted_Connection=True;Encrypt=False;";
        }

        public static DbContext Instance => _instance.Value;

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
