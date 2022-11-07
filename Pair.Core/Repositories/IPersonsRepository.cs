using Pair.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
