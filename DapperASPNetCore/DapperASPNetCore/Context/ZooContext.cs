using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace DapperASPNetCore.Context
{
    public class ZooContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public ZooContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("SqlConnection");
        }
        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}
