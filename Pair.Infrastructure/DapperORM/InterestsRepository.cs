using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using Pair.Core.Models;
using Pair.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pair.Infrastructure.DapperORM
{
    public class InterestsRepository : DapperRepositoryBase<Interest>, IInterestsRepository
    {
        public InterestsRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public override Task<IEnumerable<Interest>> Find(params string[] searchParams)
        {
            throw new NotImplementedException();
        }
    }
}
