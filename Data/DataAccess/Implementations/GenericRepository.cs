using Address_Book.Data.DataAccess.Interfaces;
using Address_Book.Data.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Address_Book.Data.DataAccess.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AddressBookDbContext _dbContext;

        private readonly DbSet<T> _dbSet;
        public GenericRepository(AddressBookDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task<T> Create(T model)
        {
            await _dbSet.AddAsync(model);

            return model;
        }

        public async Task Delete(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            _dbSet.Remove(entity);
        }

        public async Task<IEnumerable<T>> ReadAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> ReadSingle(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<bool> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync() >= 0;
        }

        public void Update(T entity)
        {
            var updateEntity = _dbSet.Attach(entity);
            updateEntity.State = EntityState.Modified;
        }
    }
}
