using Microsoft.Extensions.Configuration;
using Pair.Core.Models;
using Pair.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pair.Infrastructure.DapperORM
{
    public class InterestsPersonsRepository : DapperRepositoryBase<InterestsPersons>, IInterestsPersonsRepository
    {
        public InterestsPersonsRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public override Task<IEnumerable<InterestsPersons>> Find(params string[] searchParams)
        {
            throw new NotImplementedException();
        }
    }
}
