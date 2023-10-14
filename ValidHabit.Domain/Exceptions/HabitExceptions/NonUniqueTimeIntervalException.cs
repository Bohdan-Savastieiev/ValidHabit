using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidHabit.Domain.Exceptions.HabitExecutionFrequencyExceptions
{
    public class NonUniqueTimeIntervalException : InvalidHabitStateException
    {
        public NonUniqueTimeIntervalException(string message) : base(message) { }
    }
}