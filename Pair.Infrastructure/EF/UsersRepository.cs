using Mapster;
using Microsoft.EntityFrameworkCore;
using Pair.Core.Repositories;
using Pair.Infrastructure.EF.Security;
using Pair.Infrastructure.EF.Security.Entities;

namespace Pair.Infrastructure.EF
{
    public class UsersRepository : IRepository<Core.Models.User>, IAuthRepository<Core.Models.User>
    {
        public AuthContext _db;

        public UsersRepository(AuthContext context)
        {
            _db = context;
        }

        public Task<bool> Delete(Core.Models.User user)
        {
            var entity = user.Adapt<User>();

            _db.Users.Remove(entity);

            _db.Entry(entity).State = EntityState.Deleted;

            return Task.FromResult(true);
        }

        public async Task<IEnumerable<Core.Models.User>> Get()
        {
            var users = await _db.Users.ToListAsync();

            return users.Adapt<List<Core.Models.User>>();
        }

        public async Task<Core.Models.User> Get(int id)
        {
            var user = await _db.Users.FindAsync(new object[] { id });

            return user.Adapt<Core.Models.User>();
        }

        public async Task<long> Insert(Core.Models.User user)
        {
            var entity = user.Adapt<User>();

            var id = await _db.Users.AddAsync(entity);

            _db.Entry(entity).State = EntityState.Added;

            return id.Entity.Id;
        }

        public Task<bool> Update(Core.Models.User user)
        {
            var entity = user.Adapt<User>();

            _db.Users.Update(entity);

            _db.Entry(entity).State = EntityState.Modified;

            return Task.FromResult(true);
        }

        public async Task<Core.Models.User?> GetByLogin(string login)
        {
            var user = await _db.Users.Where(u => u.Login == login)
                 .FirstOrDefaultAsync();

            return user.Adapt<Core.Models.User?>();
        }
    }
}
