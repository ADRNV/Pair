using Microsoft.Extensions.Configuration;
using Pair.Core.Models;

namespace Pair.Infrastructure.DapperORM
{
    public class PhotosRepository : DapperRepositoryBase<Photo>
    {
        public PhotosRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public override Task<IEnumerable<Photo>> Find(params string[] searchParams)
        {
            throw new NotImplementedException();
        }
    }
}
