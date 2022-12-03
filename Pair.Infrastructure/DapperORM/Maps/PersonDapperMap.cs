using Dapper.FluentMap.Dommel.Mapping;
using Pair.Core.Models;

namespace Pair.Infrastructure.DapperORM.Maps
{
    public class PersonDapperMap : DommelEntityMap<Person>
    {
        public PersonDapperMap()
        {
            ToTable("Persons");
            Map(p => p.Id)
                .IsKey()
                .IsIdentity();
            Map(p => p.SocialLinks)
                .Ignore();

            Map(p => p.Photo)
                .Ignore();
        }
    }
}
