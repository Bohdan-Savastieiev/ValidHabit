using ValidHabit.Domain.Enums;
using ValidHabit.Domain.Exceptions.HabitExecutionFrequencyExceptions;

namespace ValidHabit.Domain.Entities
{
    public class Habit
    {
        public Habit(
            int id,
            string name,
            Guid userId,
            IEnumerable<HabitExecutionFrequency> executionFrequencies,
            IEnumerable<HabitCategory> categories)
        {
            CreationDate = DateTime.UtcNow;

            AssignExecutionFrequencies(executionFrequencies);

            AssignCategories(categories);
        }


        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime CreationDate { get; set; }

        public Guid UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public virtual Dictionary<TimeInterval, HabitExecutionFrequency> ExecutionFrequencies { get; set; }
        public virtual ICollection<HabitAndCategory> Categories { get; set; }
        public virtual ICollection<HabitRecord> Records { get; set; }


        public void AddOrUpdateExecutionFrequency(HabitExecutionFrequency frequency)
        {
            ExecutionFrequencies[frequency.TimeInterval] = frequency;
        }

        public void RemoveExecutionFrequency(TimeInterval timeInterval)
        {
            if (ExecutionFrequencies.Count <= 1)
            {
                throw new InvalidHabitStateException("A Habit must have at least one HabitExecutionFrequency.");
            }

            if (ExecutionFrequencies[timeInterval] is null)
            {
                throw new InvalidHabitStateException("Frequency with specified TimeInterval was not found in the current Habit");
            }

            ExecutionFrequencies.Remove(timeInterval);
        }

        private void AssignExecutionFrequencies(IEnumerable<HabitExecutionFrequency> frequencies)
        {
            if (frequencies == null || !frequencies.Any())
            {
                throw new InvalidHabitStateException("A Habit must have at least one HabitExecutionFrequency.");
            }

            if (frequencies.Select(x => x.TimeInterval)
                .Distinct().Count() < frequencies.Count())
            {
                throw new NonUniqueTimeIntervalException("Habit cannot have HabitExecutionFrequency with a same TimeInterval.");
            }

            ExecutionFrequencies = frequencies.ToDictionary(x => x.TimeInterval, x => x);
        }

        private void AssignCategories(IEnumerable<HabitCategory> categories)
        {
            if (categories == null || !categories.Any())
            {
                throw new InvalidHabitStateException("A Habit must have at least one HabitExecutionFrequency.");
            }

            Categories = categories.Select(x => new HabitAndCategory
            {
                Category = x,
                Habit = this
            }).ToList();
        }
    }
}
