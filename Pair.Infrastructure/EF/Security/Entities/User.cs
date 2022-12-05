namespace Pair.Infrastructure.EF.Security.Entities
{
    public class User
    {
        public long Id { get; set; }

        public int Login { get; set; }

        public string Password { get; set; }

        public bool Permissions { get; set; }
    }
}
