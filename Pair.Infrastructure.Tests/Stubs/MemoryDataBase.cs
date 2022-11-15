using ServiceStack.OrmLite.Sqlite;
using System.Data;
using Dommel;

namespace Pair.Infrastructure.Tests.Stubs
{
    public class InMemoryDatabase<T> where T : class
    {
        private readonly ServiceStack.OrmLite.OrmLiteConnectionFactory dbFactory = new ServiceStack.OrmLite.OrmLiteConnectionFactory(":memory:", SqliteOrmLiteDialectProvider.Instance);

        public IDbConnection OpenConnection() => dbFactory.OpenDbConnection();

        public void Insert(IEnumerable<T> items)
        {
            using (var db = OpenConnection())
            {
                ServiceStack.OrmLite.OrmLiteSchemaApi.CreateTableIfNotExists<T>(db);

                foreach (var item in items)
                {
                    db.Insert(item);
                }
            }
        }

        public decimal Insert(T item)
        {
            using (var db = OpenConnection())
            {
                ServiceStack.OrmLite.OrmLiteSchemaApi.CreateTableIfNotExists<T>(db);

                return (decimal)db.Insert(item);

            }
        }
    }
}
