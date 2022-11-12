using Dapper.FluentMap.Dommel.Mapping;
using Dommel;
using Pair.Infrastructure.Entities;

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
        }
    }
}
