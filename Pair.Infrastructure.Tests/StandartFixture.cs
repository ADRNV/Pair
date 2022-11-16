using Pair.Core.ORM;
using Pair.Infrastructure.Tests.Stubs;

namespace Pair.Infrastructure.Tests
{
    public class StandartFixture
    {
        public IConfiguration Configuration { get; private set; }

        public IDbConnectionFactory DbConnectionFactory { get; private set; }

        public StandartFixture()
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile(@"TestConfig.json", false)
                .Build();

            DbConnectionFactory = new SQLiteDbConnectionFactory(Configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
