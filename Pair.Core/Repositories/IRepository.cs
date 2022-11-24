namespace Pair.Core.Repositories
{
    public interface IRepository<T>
    {
        Task<int> Create(T entity);

        Task<int> Update(T entity, int id);

        Task<bool> Remove(int id);

        Task<IEnumerable<T>> Get();

        Task<T> Get(int id);
    }
}
