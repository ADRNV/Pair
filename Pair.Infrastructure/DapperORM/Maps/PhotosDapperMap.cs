using Dapper.FluentMap.Dommel.Mapping;
using Pair.Core.Models;

namespace Pair.Infrastructure.DapperORM.Maps
{
    public class PhotosDapperMap : DommelEntityMap<Photo>
    {
        public PhotosDapperMap()
        {
            ToTable("Photos");

            Map(s => s.Id)
                .IsKey()
                .IsIdentity();
            
        
        }
    }
}
