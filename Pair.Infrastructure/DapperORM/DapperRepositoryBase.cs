using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using Dommel;
using Microsoft.Extensions.Configuration;
using Pair.Core.ORM;
using Pair.Infrastructure.DapperORM.Maps;
using System.Data.SqlClient;

namespace Pair.Infrastructure.DapperORM
{
    internal abstract class DapperRepositoryBase<TEntity> : IOrmWrapper<TEntity> where TEntity : class 
    {
        private readonly IConfiguration _configuration;
        protected readonly SqlConnection _connection;

        public DapperRepositoryBase(IConfiguration configuration)
        {
            _configuration = configuration;

            if (FluentMapper.EntityMaps.IsEmpty)
            {
                FluentMapper.Initialize(c =>
                {
                    c.AddMap(new PersonDapperMap());
                    c.AddMap(new PersonDapperMap());
                    c.ForDommel();
                });
            }

            _connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }

        public async Task<int> Insert(TEntity obj)
        {
           var id = await _connection.InsertAsync(obj);

           return (int)id;
        }
            
        public async virtual Task<IEnumerable<TEntity>> Get() =>
            await _connection.GetAllAsync<TEntity>();

        public async virtual Task<TEntity> Get(int id) =>
            await _connection.GetAsync<TEntity>(id);

        public async virtual Task<bool> Delete(TEntity obj) =>
            await _connection.DeleteAsync(obj);

        public async virtual Task<bool> Update(TEntity obj) =>
            await _connection.UpdateAsync(obj);

        private bool _disposed = false;

        ~DapperRepositoryBase() =>
            Dispose();

        public void Dispose()
        {
            if (!_disposed)
            {
                _connection.Close();
                _connection.Dispose();
                _disposed = true;
            }
            GC.SuppressFinalize(this);
        }
    }
}
