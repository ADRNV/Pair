namespace Pair.Core.ORM
{
    public interface IOrmWrapper<T> where T : class
    {
        Task<int> Insert(T entity);

        Task<bool> Update(T Entity);

        Task<T> Get(int id);

        Task<IEnumerable<T>> Get();

        Task<bool> Delete(T entity);

    }
}
