using ValidHabit.Domain.Enums;

namespace ValidHabit.Domain.Entities
{
    public class HabitTimeFrame
    {
        public int Id { get; set; }
        public int DailyFrequency { get; set; }
        public DailyFrequencyType DailyFrequencyType { get; set; }
        public int BigPeriodFrequency { get; set; }
        public FrequencyType BigPeriodFrequencyType { get; set; }

        public int HabitId { get; set; }

        public virtual Habit Habit { get; set; }
    }
}