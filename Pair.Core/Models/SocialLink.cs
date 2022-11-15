namespace Pair.Core.Models
{
    public class SocialLink
    {
        public int Id { get; set; }

        public int PersonId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Link { get; set; } = string.Empty;

        public Person Person { get; set; }
    }
}
