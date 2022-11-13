using Dapper;
using Mapster;
using Microsoft.Extensions.Configuration;
using Pair.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pair.Infrastructure.DapperORM
{
    public class PersonsWrapper : DapperRepositoryBase<Person>
    {
        public PersonsWrapper(IConfiguration configuration) : base(configuration)
        {
              
        }

        public async override Task<IEnumerable<Person>> Get()
        {
            var sql = "SELECT * FROM Persons P INNER JOIN SocialLinks S ON S.PersonId = P.Id";

            return await _connection.QueryAsync(sql, (Person p, SocialLink s) =>
            {
                p.SocialLinks?.Add(s);

                return p;
            });
        }
    }
}
