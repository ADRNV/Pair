using Pair.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pair.Core.ORM
{
    public interface IPersonsRepository<P> where P : Person
    {
        Task<long> Insert(P entity);

        Task<bool> Update(P Entity);

        Task<P> Get(int id);

        Task<IEnumerable<P>> Get();

        Task<bool> Delete(P entity);
    }
}
