using Pair.Core.Models;
using Pair.Core.Repositories;
using Pair.Core.Services;

namespace Pair.Services
{
    public class AuthService : IAuthService<User>
    {
        private readonly IAuthRepository<User> _repository;

        public AuthService(IAuthRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<bool?> SignIn(User user)
        {
            var searchedUser = await _repository.GetByLogin(user.Login);

            if (user is null)
            {
                return null;
            }

            return searchedUser?.Password == user.Password;
        }
    }
}
