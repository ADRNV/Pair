using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pair.Core.Models;

namespace Pair.Core.Repositories
{
    public interface IAuthRepository<T> : IRepository<T>
    {
        Task<User?> GetByLogin(string login);
    }
}
