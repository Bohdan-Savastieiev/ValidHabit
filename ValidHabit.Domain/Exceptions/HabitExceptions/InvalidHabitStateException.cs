using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidHabit.Domain.Exceptions;

namespace ValidHabit.Domain.Exceptions.HabitExecutionFrequencyExceptions
{
    public class InvalidHabitStateException : DomainException
    {
        public InvalidHabitStateException(string message) : base(message) { }
    }
}