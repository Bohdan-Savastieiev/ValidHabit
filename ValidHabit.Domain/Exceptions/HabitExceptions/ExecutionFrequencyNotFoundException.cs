using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidHabit.Domain.Exceptions.HabitExecutionFrequencyExceptions
{
    public class ExecutionFrequencyNotFoundException : EntityNotFoundException
    {
        public ExecutionFrequencyNotFoundException(string message) : base(message) { }
    }
}