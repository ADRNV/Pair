using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Pair.Core.ORM
{
    public interface IOrmWrapper<T> where T : class
    {
        Task<int> Insert(T entity);

        Task<bool> Update(T Entity);

        Task<T> Get(int id);

        Task<IEnumerable<T>> LoadTable();

    }
}
