using Microsoft.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace EmployeeApi.DAL
{
    public sealed class DataAccessService
    {
        private static DataAccessService _instance;
        private static readonly object _lock = new object();
        private readonly string _connectionString;

        private DataAccessService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public static DataAccessService GetInstance(string connectionString)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new DataAccessService(connectionString);  // Deferred loading  
                }
            }
            return _instance;
        }

        public async Task<DataTable> ExecuteQueryAsync(string query, SqlParameter[] parameters = null)
        {
            Logger.Instance.Log($"Executing Query: {query}");

            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    await conn.OpenAsync();
                    var table = new DataTable();
                    table.Load(await cmd.ExecuteReaderAsync());
                    return table;
                }
            }
        }

        public async Task<int> ExecuteNonQueryAsync(string query, SqlParameter[] parameters = null)
        {
            Logger.Instance.Log($"Executing NonQuery: {query}");

            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    await conn.OpenAsync();
                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
