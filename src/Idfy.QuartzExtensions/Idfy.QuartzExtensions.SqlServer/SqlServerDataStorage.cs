using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Idfy.QuartzExtensions.SqlServer
{
    internal class SqlServerDataStorage
    {
        private readonly string _connectionString;

        internal SqlServerDataStorage(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        private async Task<IDbConnection> GetConnection()
        {
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(_connectionString);
                await connection.OpenAsync();
                return connection;
            }
            catch (Exception)
            {
                connection?.Dispose();
                throw;
            }
        }
    }
}