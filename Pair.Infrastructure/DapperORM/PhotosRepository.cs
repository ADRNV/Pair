using Dapper;
using Microsoft.Extensions.Configuration;
using Pair.Core.Models;

namespace Pair.Infrastructure.DapperORM
{
    public class PhotosRepository : DapperRepositoryBase<Photo>
    {
        public PhotosRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public override async Task<IEnumerable<Photo>> Find(params string[] searchParams)
        {
            var sql = "SELECT * FROM Photos P WHERE P.Id = @id";

            var paramters = new DynamicParameters();

            paramters.Add("@id", searchParams[0]);

            return await _connection.QueryAsync<Photo>(sql, paramters);
        }
    }
}
