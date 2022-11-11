using Dapper;
using DapperExtensions;
using Pair.Core.ORM;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Pair.Infrastructure.DapperORM
{
    public class DapperWrapper<TEntity> : IOrmWrapper<TEntity> where TEntity: class
    {
        private IDbConnection _dbConnection;

        public DapperWrapper(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<int> Insert(TEntity entity) 
        {
            using (var connection = new SqlConnection(_dbConnection.ConnectionString))
            {
                return await connection.InsertAsync(entity);
            }
        }

        public async Task<bool> Update(TEntity entity)
        {
            using (var connection = new SqlConnection(_dbConnection.ConnectionString))
            {
                return await connection.UpdateAsync(entity);
            }
        }

        public async Task<IEnumerable<TEntity>> LoadTable()
        {
            using (var connection = new SqlConnection(_dbConnection.ConnectionString))
            {
                return await connection.GetListAsync<TEntity>();
            }
        }

        public async Task<TEntity> Get(int id)
        {
            using (var connection = new SqlConnection(_dbConnection.ConnectionString))
            {
                return await connection.GetAsync<TEntity>(id);
            }
        }

        public async Task<TMapped> GetWith<TParrent, TChild, TMapped>(int id, Func<TParrent, TChild, TMapped> mapper, string on = "Id = Id") where TParrent : class where TChild : class
        {
            var parrent = typeof(TParrent);

            var child = typeof(TChild);

            var parrentProperties = parrent.GetProperties();

            var childProperties = child.GetProperties();

            var childPropNames = new StringBuilder();

            var parrentPropNames = new StringBuilder();

            foreach (var property in parrentProperties)
            {
                parrentPropNames.Append($" {property.Name} ");
            }

            foreach (var property in childProperties)
            {
                childPropNames.Append($"{property.Name}");
            }

            string sql = new StringBuilder()
                .Append($"SELECT {parrentPropNames} FROM {parrent.Name} P INNER JOIN {child.Name} C")
                .Append($"ON P.{on} = C.{on}")
                .Append($"WHERE {on} = {id}")
                .ToString();

            using (var connection = new SqlConnection(_dbConnection.ConnectionString))
            {
                var join = await connection.QueryAsync(sql, mapper);

                return join.First();
            }
        }
    }
}
