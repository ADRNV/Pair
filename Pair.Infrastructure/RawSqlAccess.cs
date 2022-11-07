using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace Pair.Infrastructure
{
    //Fix unsafe procedures
    public class RawSqlAccess
    {
        private readonly IConfiguration _configuration;

        public RawSqlAccess(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<TEntity>> LoadTable<TEntity>(string procedure, string connectionId = "Default", 
            params object[] parameters)
        {
            using(var connection = new SqlConnection(_configuration.GetConnectionString(connectionId)))
            {
               return await connection.QueryAsync<TEntity>(procedure, parameters);
            }
        }

        public async Task<IEnumerable<TEntity>> Get<TEntity>(string procedure, string connectionId = "Default",
            params object[] parameters)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString(connectionId)))
            {
                return await connection.QueryAsync<TEntity>(procedure, parameters);
            }
        }

        public async Task<object> Insert<TEntity>(string procedure, object parameter, string connectionId = "Default")
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString(connectionId)))
            {
                return await connection.ExecuteAsync(procedure, parameter);
            }
        }

        public async Task<int> Update<TEntity>(string procedure, object parameter, string connectionId = "Default")
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString(connectionId)))
            {
                return await connection.ExecuteAsync(procedure, parameter);
            }
        }
    }
}
