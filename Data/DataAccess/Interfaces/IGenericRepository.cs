namespace Address_Book.Data.DataAccess.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Create(T model);
        void Update(T update);
        Task Delete(int id);
        Task<T> ReadSingle(int id);
        Task<IEnumerable<T>> ReadAll();

        Task<bool> SaveAsync();


    }
}
