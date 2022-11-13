using Dapper;
using Microsoft.Extensions.Configuration;
using Pair.Core.Models;

namespace Pair.Infrastructure.DapperORM
{
    public class SocialLinksRepository : DapperRepositoryBase<SocialLink>
    {
        public SocialLinksRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public override Task<IEnumerable<SocialLink>> Get()
        {
            var sql = "SELECT * FROM SocialLinks S JOIN Persons P ON P.Id = S.PersonId";

            _connection.QueryAsync<SocialLink, Person, SocialLink>(sql, (s, p) =>
            {
                s.Person = p;

                return s;
            });

            return base.Get();
        }
    }
}
