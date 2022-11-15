using System.Data;

namespace Pair.Core.ORM
{
    public interface IDbConnectionFactory
    {
        IDbConnection GetConnection();
    }
}
