namespace Pair.Core.Models
{
    public class User
    {
        public long Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public bool Permissions { get; set; }
    }
}
