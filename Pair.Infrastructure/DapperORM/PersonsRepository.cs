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
            var sql = @"SELECT DISTINCT P.Id, P.Age, P.Bio, P.ImageUri, P.Sex, P.SocialCredit, I.Id, I.InterestName 
                        FROM Persons P 
                        INNER JOIN InterestsPersons IP ON IP.PersonId = P.Id 
                        INNER JOIN Interests I ON IP.PersonId = P.Id ORDER BY P.Id";

            List<Person> persons = new();
            
            Person? person = null;

            await _connection.QueryAsync<Person, Interest, Person>(sql, (p, i) =>
            {
                person ??= p;

                if (person.Id == p.Id)
                {
                    person.Interests.Add(i);
                }
                else
                {
                    persons.Add(person);
                    person = null;
                }
                
                return p;
            });

            return persons;
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
