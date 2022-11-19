using Pair.Core.Models;

namespace Pair.Core.Repositories
{
    public interface ISocialLinksRepository
    {
        Task<int> Create(SocialLink SocialLink);

        Task<int> Update(SocialLink SocialLink, int id);

        Task<bool> Remove(int id);

        Task<IEnumerable<SocialLink>> Get();

        Task<SocialLink> Get(int id);
    }
}
