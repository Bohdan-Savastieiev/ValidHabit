using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidHabit.Domain.Entities
{
    public class HabitAndCategory
    {
        public int Id { get; set; }

        public int HabitId { get; set; }
        public virtual Habit Habit { get; set; }

        public int CategoryId { get; set; }
        public virtual HabitCategory Category { get; set; }
    }
}