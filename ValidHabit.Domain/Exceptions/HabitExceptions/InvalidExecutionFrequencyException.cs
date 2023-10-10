using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidHabit.Domain.Exceptions.HabitExecutionFrequencyExceptions
{
    public class InvalidExecutionFrequencyException : DomainException
    {
        public InvalidExecutionFrequencyException(string message) : base(message) { }
    }
}