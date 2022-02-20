using Microsoft.Extensions.Logging;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace IliaCodeTest.Repository.DbContext
{
    public class IliaCodeTestDbContext : IIliaCodeTestDbContext
    {
        private readonly string _connectionString;
        private readonly ILogger<IliaCodeTestDbContext> _logger;

        public IliaCodeTestDbContext(ILogger<IliaCodeTestDbContext> logger, IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnectionString");
            _logger = logger;
        }

        public DbConnection OpenConnection()
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection;
          
        }

    }
}
