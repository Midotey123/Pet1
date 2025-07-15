namespace Pet1.Interfaces
{
    public interface IRep<T>
        where T : class, IEntity
    {
        Task<IEnumerable<T>> Get();
        Task<T> GetById(int id);
        Task<bool> Add(T item);
        Task<bool> Update(T newItem);
        Task<bool> Delete(int id);
        int Save();
    }
}
