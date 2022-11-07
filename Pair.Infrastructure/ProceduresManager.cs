using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace Pair.Infrastructure
{
    internal class ProceduresManager
    {
        private readonly IDbConnection _dbConnection;

        private const string FindAllStoredProcedures = "SELECT ROUTINE_NAME FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_TYPE = 'PROCEDURE';";

        public ProceduresManager(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<string>> FindAll()
        {
            using (var connection = new SqlConnection(_dbConnection.ConnectionString))
            {
               return await connection.QueryAsync<string>(FindAllStoredProcedures);
            }
        }

        public async Task<string> Find(string name)
        {
            using (var connection = new SqlConnection(_dbConnection.ConnectionString))
            {
                return await connection.QueryAsync<string>(FindAllStoredProcedures).First(name);
            }
        }
    }
}
