using Dapper.FluentMap.Dommel.Mapping;
using Pair.Infrastructure.Entities;

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
        }
    }
}
