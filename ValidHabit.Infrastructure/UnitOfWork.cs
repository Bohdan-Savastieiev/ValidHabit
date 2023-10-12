using System;
using ValidHabit.Domain.Abstractions;
using ValidHabit.Domain.Primitives;
using ValidHabit.Infrastructure.Data;

namespace ValidHabit.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HabitTrackerDbContext _dbContext;
        private readonly Dictionary<Type, IRepository> _repositories = new Dictionary<Type, IRepository>();

        public UnitOfWork(HabitTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IRepository<T>? GetRepository<T>() 
            where T : Entity
        {
            if (_repositories.TryGetValue(typeof(T), out var repository))
            {
                return (IRepository<T>)repository;
            }
            else
            {
                return null;
            }
        }

        public Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}