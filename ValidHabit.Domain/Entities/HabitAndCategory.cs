using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidHabit.Domain.Primitives;

namespace ValidHabit.Domain.Entities
{
    public class HabitAndCategory : Entity
    {
        public int HabitId { get; init; }
        public virtual Habit Habit { get; init; }

        public int CategoryId { get; init; }
        public virtual HabitCategory Category { get; init; }
    }
}