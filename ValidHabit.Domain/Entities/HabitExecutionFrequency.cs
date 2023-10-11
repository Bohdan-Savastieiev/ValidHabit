using ValidHabit.Domain.Enums;
using ValidHabit.Domain.Constants;
using ValidHabit.Domain.Exceptions.HabitExecutionFrequencyExceptions;
using ValidHabit.Domain.Primitives;

namespace ValidHabit.Domain.Entities
{
    public class HabitExecutionFrequency : Entity
    {
        // Properties
        public int Value { get; private set; }
        public FrequencyType FrequencyType { get; private set; }
        public TimeInterval TimeInterval { get; init; }

        public int HabitId { get; init; }
        public Habit Habit { get; private set; }

        // Methods
        public void UpdateExecutionFrequency(int newValue, FrequencyType newFrequencyType)
        {
            Value = newValue;
            FrequencyType = newFrequencyType;
            Validate();
        }

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