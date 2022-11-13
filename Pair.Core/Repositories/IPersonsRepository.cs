using Pair.Core.Models;

namespace Pair.Core.Repositories
{
    public interface IPersonsRepository
    {
        Task<int> Create(Person person);

        Task<int> Update(Person person, int id);

        Task<bool> Remove(int id);

        Task<IEnumerable<Person>> Get();

        Task<Person> Get(int id);
    }
}
