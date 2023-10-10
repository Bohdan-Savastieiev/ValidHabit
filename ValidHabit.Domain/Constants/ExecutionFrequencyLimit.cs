using ValidHabit.Domain.Enums;

namespace ValidHabit.Domain.Constants
{
    public static class ExecutionFrequencyLimit
    {
        public static readonly Dictionary<(FrequencyType, TimeInterval), int> MaxLimits = new()
        {
            {(FrequencyType.Hours, TimeInterval.PerDay), 24},
            {(FrequencyType.Minutes, TimeInterval.PerDay), 1440},
            {(FrequencyType.Times, TimeInterval.PerDay), 100},

            {(FrequencyType.Hours, TimeInterval.PerWeek), 168},
            {(FrequencyType.Minutes, TimeInterval.PerWeek), 10080},
            {(FrequencyType.Times, TimeInterval.PerWeek), 1000},

            {(FrequencyType.Hours, TimeInterval.PerMonth), 744},
            {(FrequencyType.Minutes, TimeInterval.PerMonth), 44640},
            {(FrequencyType.Times, TimeInterval.PerMonth), 10000},

            {(FrequencyType.Hours, TimeInterval.PerYear), 8784},
            {(FrequencyType.Minutes, TimeInterval.PerYear), 527040},
            {(FrequencyType.Times, TimeInterval.PerYear), 10000}
        };
    }
}
