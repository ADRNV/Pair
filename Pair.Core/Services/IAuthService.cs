using Pair.Core.Models;

namespace Pair.Core.Services
{
    public interface IAuthService
    {
        public Task<bool> SignIn(User user);
    }
}
