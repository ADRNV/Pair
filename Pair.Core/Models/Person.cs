namespace Pair.Core.Models
{
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Bio { get; set; }

        public int Age { get; set; }

        public IList<SocialLink>? SocialLinks { get; set; }

        public string Sex { get; set; } = string.Empty;

        public string ImageUri { get; set; }

        public int SocialCredit { get; set; }

    }
}
