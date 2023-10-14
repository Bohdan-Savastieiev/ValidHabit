using ValidHabit.Domain.Enums;
using ValidHabit.Domain.Exceptions.HabitExceptions;
using ValidHabit.Domain.Exceptions.HabitExecutionFrequencyExceptions;
using ValidHabit.Domain.Primitives;
using ValidHabit.Domain.ValueObjects;

namespace ValidHabit.Domain.Entities
{
    public class Habit : Entity
    {
        //Fields
        private Dictionary<TimeInterval, HabitExecutionFrequency> _executionFrequencies;
        private List<HabitAndCategory> _categories;

        // Properties
        public Name Name { get; set; }
        public string? Description { get; set; }
        public DateTimeOffset CreationDate { get; }
        
        public int UserId { get; init; }
        public virtual User User { get; private set; }
        public virtual ICollection<HabitExecutionFrequency> ExecutionFrequencies
        {
            get
            {
                var result = _executionFrequencies as ICollection<HabitExecutionFrequency>;
                if (result is null)
                {
                    throw new InvalidHabitStateException("The ExecutionFrequencies dictionary was not successfully mapped to the ICollection");
                }

                return result;
            }
            set
            {
                if (value == null || !value.Any())
                {
                    throw new InvalidHabitStateException("A Habit must have at least one HabitExecutionFrequency.");
                }

                if (value.Select(x => x.TimeInterval).Distinct().Count() < value.Count())
                {
                    throw new NonUniqueTimeIntervalException("Habit cannot have HabitExecutionFrequency with the same TimeInterval.");
                }

                _executionFrequencies = value.ToDictionary(x => x.TimeInterval, x => x);
            }
        }
        public virtual ICollection<HabitAndCategory> Categories
        {
            get
            {
                var result = _categories as ICollection<HabitAndCategory>;
                if (result is null)
                {
                    throw new InvalidHabitStateException("Categories were not successfully mapped to the ICollection");
                }

                return result;
            }
            set
            {
                if (value == null || !value.Any())
                {
                    throw new InvalidHabitStateException("A Habit must have at least one category.");
                }

                _categories = value.ToList();
            }
        }
        public virtual ICollection<HabitRecord> Records { get; private set; }

        // Methods
        public void AddOrUpdateExecutionFrequency(HabitExecutionFrequency frequency)
        {
            _executionFrequencies[frequency.TimeInterval] = frequency;
        }

        public void RemoveExecutionFrequency(TimeInterval timeInterval)
        {
            if (_executionFrequencies.Count <= 1)
            {
                throw new InvalidHabitStateException("A Habit must have at least one HabitExecutionFrequency.");
            }

            if (!_executionFrequencies.ContainsKey(timeInterval))
            {
                throw new InvalidHabitStateException("Frequency with specified TimeInterval was not found in the current Habit");
            }

            _executionFrequencies.Remove(timeInterval);
        }
    }
}
