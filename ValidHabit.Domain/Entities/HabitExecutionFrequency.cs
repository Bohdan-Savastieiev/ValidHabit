using ValidHabit.Domain.Enums;
using ValidHabit.Domain.Constants;
using ValidHabit.Domain.Exceptions.HabitExecutionFrequencyExceptions;

namespace ValidHabit.Domain.Entities
{
    public class HabitExecutionFrequency
    {
        // Constructor
        public HabitExecutionFrequency(int id, int value, FrequencyType frequencyType, TimeInterval timeInterval, int habitId)
        {
            Id = id;
            Value = value;
            FrequencyType = frequencyType;
            TimeInterval = timeInterval;
            HabitId = habitId;

            Validate();
        }

        // Properties
        public int Id { get; init; }
        public int Value { get; init; }
        public FrequencyType FrequencyType { get; init; }
        public TimeInterval TimeInterval { get; init; }

        public int HabitId { get; init; }
        public Habit Habit { get; init; }

        // Methods
        private void Validate()
        {
            if (Value <= 0)
            {
                throw new InvalidExecutionFrequencyException("Value of the ExecutionFrequency has to be greater than zero.");
            }

            if (ExecutionFrequencyLimit.MaxLimits.TryGetValue((FrequencyType, TimeInterval), out int maxLimit))
            {
                if (Value > maxLimit)
                {
                    if (FrequencyType == FrequencyType.Times)
                    {
                        throw new InvalidExecutionFrequencyException($"Value is too big.");
                    }
                    else
                    {
                        throw new InvalidExecutionFrequencyException($"Value cannot be greater than {maxLimit} {FrequencyType} {TimeInterval}.");
                    }
                }
            }
            else
            {
                throw new InvalidExecutionFrequencyException("No such combination of FrequencyType and TimeInterval");
            }
        }
    }
}