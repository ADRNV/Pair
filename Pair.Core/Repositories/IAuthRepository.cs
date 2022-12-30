using Pair.Core.Models;

namespace Pair.Core.Repositories
{
    public interface IAuthRepository<T> : IRepository<T>
    {
        Task<User?> GetByLogin(string login);
    }
}
