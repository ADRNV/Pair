using Dapper;
using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using Dommel;
using Microsoft.Extensions.Configuration;
using Pair.Core.ORM;
using Pair.Infrastructure.DapperORM.Maps;
using System.Data;
using System.Data.SqlClient;

namespace Pair.Infrastructure.DapperORM
{
    public abstract class DapperRepositoryBase<TEntity> : IOrmWrapper<TEntity>, IDisposable where TEntity : class
    {
        private readonly IConfiguration _configuration;

        protected readonly IDbConnection _connection;

        protected readonly IDbConnectionFactory _dbConnectionFactory;

        public DapperRepositoryBase(IConfiguration configuration)
        {
            InitMaps();

            _configuration = configuration;

            _connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }

        public DapperRepositoryBase(IDbConnectionFactory dbConnectionFactory)
        {
            InitMaps();

            _dbConnectionFactory = dbConnectionFactory;

            _connection = _dbConnectionFactory.GetConnection();
        }

        private void InitMaps()
        {
            if (FluentMapper.EntityMaps.IsEmpty)
            {
                FluentMapper.Initialize(c =>
                {
                    c.AddMap(new PersonDapperMap());
                    c.AddMap(new SoclialLinkDapperMap());
                    c.ForDommel();
                });
            };
        }

        public async Task<long> Insert(TEntity obj)
        {
            var id = await _connection.InsertAsync(obj);
            return Convert.ToInt64(id);
        }

        public async virtual Task<IEnumerable<TEntity>> Get() =>
            await _connection.GetAllAsync<TEntity>();

        public async virtual Task<IEnumerable<TEntity>> Get(int pageNumber, int pageSize) =>
            await _connection.GetPagedAsync<TEntity>(pageNumber, pageSize);
       
        public async virtual Task<TEntity> Get(int id) =>
            await _connection.GetAsync<TEntity>(id);

       
        public async virtual Task<bool> Delete(TEntity obj) =>
            await _connection.DeleteAsync(obj);

        public async virtual Task<bool> Update(TEntity obj) =>
            await _connection.UpdateAsync(obj);

        public abstract Task<IEnumerable<TEntity>> Find(params string[] searchParams);
        
        private bool _disposed = false;

        ~DapperRepositoryBase() =>
            Dispose();

        public virtual void Dispose()
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
