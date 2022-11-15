using Pair.Core.ORM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pair.Infrastructure.Tests.Stubs
{
    public class SQLiteDbConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connectionString;

        public SQLiteDbConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection GetConnection()
        {
            return new SQLiteConnection(_connectionString);
        }
    }
}
