using Pair.Core.Models;
using Pair.Core.Repositories;
using Pair.Core.Services;
using Pair.Infrastructure.EF.Security.Entities.Configurations;
using System.Security.Principal;

namespace Pair.Services
{
    public class SignInService : IAuthService
    {
        private IAuthRepository<User> _userRepository;
        
        public SignInService(IAuthRepository<User> usersRepository)
        {
            _userRepository = usersRepository;
        }

        public async Task<bool> CanSignIn(User user)
        {
            var signingUser = await _userRepository.GetByLogin(user.Login);

            if(signingUser == null)
            {
                return false;
            }

            return signingUser.Password == user.Password;
        }

        public async Permissions GetUserByLogin(string login)
        {
            return _userRepository.GetByLogin(login);
        }


    }
}
