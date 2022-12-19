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

        public override async Task<IEnumerable<Person>> Find(params string[] searchParams)
        {
            var sql = "SELECT * FROM Persons P WHERE Name LIKE %@name% OR Bio LIKE %bio%";

            var parameters = new DynamicParameters();

            parameters.Add("@name", searchParams[0]);

            parameters.Add("@bio", searchParams[1]);

            return await _connection.QueryAsync<Person>(sql, parameters);
        }
    }
}
