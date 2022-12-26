using Dapper;
using Dapper.Contrib.Extensions;
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
            var sql = @"SELECT * FROM Persons P INNER JOIN InterestsPersons I ON I.PersonId = P.Id";

            return await _connection.QueryAsync<Person, Interest, Person>(sql, (p, i) =>
            {
                p.Interests?.Add(i);

                return p;
            });

        }

        public override async Task<IEnumerable<Person>> Find(params string[] searchParams)
        {
            var sql = "SELECT * FROM Persons P WHERE Name LIKE @name OR Bio LIKE @bio";

            var parameters = new DynamicParameters();

            parameters.Add("@name", $"%{searchParams[0]}%");

            parameters.Add("@bio", $"%{searchParams[1]}%");

            return await _connection.QueryAsync<Person>(sql, parameters);
        }
    }
}
