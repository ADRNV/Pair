using Dapper.FluentMap.Dommel.Mapping;
using Pair.Core.Models;

namespace Pair.Infrastructure.DapperORM.Maps
{
    public class SoclialLinkDapperMap : DommelEntityMap<SocialLink>
    {
        public SoclialLinkDapperMap()
        {
            ToTable("SocialLinks");

            Map(s => s.Id)
                .IsKey()
                .IsIdentity();

            Map(s => s.Person)
                .Ignore();
        }
    }
}
