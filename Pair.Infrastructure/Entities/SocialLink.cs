using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pair.Infrastructure.Entities
{
    public class SocialLink
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Link { get; set; } = string.Empty;
    }
}
