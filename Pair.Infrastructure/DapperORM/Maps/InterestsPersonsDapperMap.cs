using Dapper.FluentMap.Dommel.Mapping;
using Pair.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pair.Infrastructure.DapperORM.Maps
{
    public class InterestsPersonsDapperMap : DommelEntityMap<InterestsPersons>
    {
        public InterestsPersonsDapperMap()
        {
            ToTable("InterestsPersons");
            Map(i => i.Id)
                .IsKey()
                .IsIdentity();
        }
    }
}
