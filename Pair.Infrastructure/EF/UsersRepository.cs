using Microsoft.EntityFrameworkCore;
using Pair.Core.Repositories;
using Pair.Infrastructure.EF.Security;
using Pair.Infrastructure.EF.Security.Entities;

namespace Pair.Infrastructure.EF
{
    public class UsersRepository : IRepository<User>
    {
        public AuthContext _db;

        public UsersRepository(AuthContext context)
        {
            _db = context;
        }

        public Task<bool> Delete(User user)
        {
            _db.Users.Remove(user);

            return Task.FromResult(true);
        }

        public async Task<IEnumerable<User>> Get()
        {
            return await _db.Users.ToListAsync();
        }

        public async Task<User> Get(int id)
        {
            return await _db.Users.FindAsync(new object[] {id});
        }

        public Task<long> Insert(User user)
        {
            _db.Users.AddAsync(user);

            return Task.FromResult(user.Id);
        }

        public Task<bool> Update(User user)
        {
            _db.Users.Update(user);

            return Task.FromResult(true);
        }
    }
}
