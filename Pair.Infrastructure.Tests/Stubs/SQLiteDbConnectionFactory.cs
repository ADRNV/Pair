﻿using Pair.Core.ORM;
using System.Data;
using System.Data.SQLite;

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
