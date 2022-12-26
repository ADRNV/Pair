using Dapper.FluentMap.Dommel.Mapping;
using Pair.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pair.Infrastructure.DapperORM.Maps
{
    public class InterestDapperMap : DommelEntityMap<Interest>
    {
        public InterestDapperMap()
        {
            ToTable("Interests");
            Map(i => i.Id)
                .IsKey()
                .IsIdentity();
        }
    }
}
