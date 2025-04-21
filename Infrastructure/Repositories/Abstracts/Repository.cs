using AuthenticationService.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationService.Infrastructure.Repositories.Abstracts
{
    public class Repository<T, TKey> : IRepository<T, TKey> where T : class
    {
        protected readonly DbContext _dbContext;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> Create(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<bool> Delete(TKey id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            if (entity is null)
                return false;

            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public virtual async Task<IEnumerable<T>> GetAll(int pageNumber, int pageSize)
        {
            if (pageNumber < 1)
                throw new ArgumentOutOfRangeException(nameof(pageNumber), "Page number must be >= 1.");
            if (pageSize < 1)
                throw new ArgumentOutOfRangeException(nameof(pageSize), "Page size must be >= 1.");

            return await _dbContext.Set<T>()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public virtual async Task<T?> GetById(TKey id)
        {
            if (EqualityComparer<TKey>.Default.Equals(id, default))
                throw new ArgumentNullException(nameof(id));

            return await _dbContext.Set<T>().FindAsync(id);
        }

        public virtual async Task<T?> GetByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            return await _dbContext.Set<T>().FirstOrDefaultAsync(
                e => EF.Property<string>(e, "Name") == name);
        }

        public virtual async Task<T> Update(TKey id, T entity)
        {
            if (EqualityComparer<TKey>.Default.Equals(id, default))
                throw new ArgumentNullException(nameof(id));

            var existingEntity = await _dbContext.Set<T>().FindAsync(id);
            if (existingEntity is null)
                throw new InvalidOperationException("The entity to update was not found.");

            _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
