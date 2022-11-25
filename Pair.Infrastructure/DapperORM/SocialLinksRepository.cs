using Dapper;
using Microsoft.Extensions.Configuration;
using Pair.Core.Models;
using Pair.Core.ORM;
using Pair.Core.Repositories;

namespace Pair.Infrastructure.DapperORM
{
    public class SocialLinksRepository : DapperRepositoryBase<SocialLink>, ISocialLinksRepository
    {
        public SocialLinksRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public SocialLinksRepository(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
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
