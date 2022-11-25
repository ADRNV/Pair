using Dapper;
using Microsoft.Extensions.Configuration;
using Pair.Core.Models;
using Pair.Core.ORM;
using Pair.Core.Repositories;

namespace Pair.Infrastructure.DapperORM
{
    public class PersonsRepository : DapperRepositoryBase<Person>, IPersonsRepository
    {
        public PersonsRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public PersonsRepository(IDbConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }

        public async override Task<IEnumerable<Person>> Get()
        {
            var sql = @"SELECT * FROM Persons P INNER JOIN SocialLinks S ON S.PersonId = P.Id";

            return await _connection.QueryAsync<Person, SocialLink, Person>(sql, (p, s) =>
            {
                p.SocialLinks?.Add(s);

                return p;
            });
        }
    }
}
