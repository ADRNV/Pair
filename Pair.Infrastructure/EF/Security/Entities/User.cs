using Pair.Infrastructure.EF.Security.Entities.Configurations;

namespace Pair.Infrastructure.EF.Security.Entities
{
    public class User
    {
        public long Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public Permissions Permissions { get; set; }
    }
}
