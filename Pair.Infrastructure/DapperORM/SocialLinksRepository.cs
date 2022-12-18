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

        public override async Task<IEnumerable<SocialLink>> Find(params string[] searchParams)
        {
            var sql = "SELECT * FROM SocialLinks S WHERE S.Name = @name OR S.Link = @link";

            var parameters = new DynamicParameters();

            parameters.Add("@name", searchParams[0]);

            parameters.Add("@link", searchParams[1]);

            return await _connection.QueryAsync<SocialLink>(sql, parameters);
        }

        public override async Task<IEnumerable<SocialLink>> Get()
        {
            var sql = "SELECT * FROM SocialLinks S JOIN Persons P ON P.Id = S.PersonId";

            return await _connection.QueryAsync<SocialLink, Person, SocialLink>(sql, (s, p) =>
            {
                s.Person = p;

                return s;
            });
        }
    }
}
