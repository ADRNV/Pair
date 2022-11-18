using Pair.Core.ORM;
using Pair.Infrastructure.Tests.Stubs;
using System.Data;

namespace Pair.Infrastructure.Tests
{
    public class StandartFixture
    {
        public IConfiguration Configuration { get; private set; }
        
        public IDbConnectionFactory DbConnectionFactory { get; private set; }

        public IDbConnection DbConnection { get; private set; }

        public string? ConnectionString { get; private set; }

        public StandartFixture()
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile(@"TestConfig.json", false)
                .Build();

            ConnectionString = Configuration.GetConnectionString("DefaultConnection");

            DbConnectionFactory = new SQLiteDbConnectionFactory(ConnectionString);

            DbConnection = DbConnectionFactory.GetConnection();
        }
    }
}
