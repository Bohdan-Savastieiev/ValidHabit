using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ValidHabit.Application.Interfaces.Repositories;
using ValidHabit.Domain.Primitives;
using ValidHabit.Infrastructure.Data;

namespace ValidHabit.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> 
        where T : Entity
    {
        private HabitTrackerDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public Repository(HabitTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            var entity = await _dbSet.SingleOrDefaultAsync(x => x.Id == id);
            return entity;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var entities = await _dbSet.ToListAsync();
            return entities;
        }
        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            var entities = await _dbSet.Where(predicate).ToListAsync();
            return entities;
        }

        public async Task AddAsync(T entity)
        {
            await _dbContext.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }
    }
}