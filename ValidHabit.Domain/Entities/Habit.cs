using ValidHabit.Domain.Enums;
using ValidHabit.Domain.Exceptions.HabitExecutionFrequencyExceptions;

namespace ValidHabit.Domain.Entities
{
    public class Habit
    {
        // Constructor
        public Habit(
            int id,
            string name,
            Guid userId,
            string? description,
            IEnumerable<HabitExecutionFrequency> executionFrequencies,
            IEnumerable<HabitCategory> categories)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description;
            UserId = userId;
            CreationDate = DateTime.UtcNow;

            AssignExecutionFrequencies(executionFrequencies);
            AssignCategories(categories);
        }

        // Properties
        public int Id { get; init; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreationDate { get; init; }
        public Guid UserId { get; init; }

        public virtual ApplicationUser User { get; private set; }
        public virtual Dictionary<TimeInterval, HabitExecutionFrequency> ExecutionFrequencies { get; private set; }
        public virtual ICollection<HabitAndCategory> Categories { get; private set; }
        public virtual ICollection<HabitRecord> Records { get; private set; }

        // Methods
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

            if (!ExecutionFrequencies.ContainsKey(timeInterval))
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

            if (frequencies.Select(x => x.TimeInterval).Distinct().Count() < frequencies.Count())
            {
                throw new NonUniqueTimeIntervalException("Habit cannot have HabitExecutionFrequency with the same TimeInterval.");
            }

            ExecutionFrequencies = frequencies.ToDictionary(x => x.TimeInterval, x => x);
        }

        private void AssignCategories(IEnumerable<HabitCategory> categories)
        {
            if (categories == null || !categories.Any())
            {
                throw new InvalidHabitStateException("A Habit must have at least one category.");
            }

            Categories = categories.Select(x => new HabitAndCategory
            {
                Category = x,
                Habit = this
            }).ToList();
        }
    }
}
