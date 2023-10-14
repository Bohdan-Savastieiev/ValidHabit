using Microsoft.EntityFrameworkCore.ChangeTracking;
using ValidHabit.Application.Interfaces;

namespace ValidHabit.Application.Services
{
    public class HabitTrackerService : IHabitTrackerService
    {
        private readonly IHabitTrackerDbContext _dbContext;

        public HabitTrackerService(IHabitTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

         
    }
}