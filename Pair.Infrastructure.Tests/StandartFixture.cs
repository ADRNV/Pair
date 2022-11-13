using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace Pair.Infrastructure.Tests
{
    public class StandartFixture
    {
        public IConfiguration Configuration { get; private set; }

        public StandartFixture()
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile(@"TestConfig.json", false)
                .Build();
        }
    }
}
