using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidHabit.Domain.Exceptions.HabitExceptions;
using ValidHabit.Domain.Primitives;

namespace ValidHabit.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public const int MaxLength = 50;

        private readonly string _value;

        public Name(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new InvalidNameException(GetExceptionMessage("Name is empty."));
            }

            if (value.Length > MaxLength)
            {
                throw new InvalidNameException(GetExceptionMessage($"Name cannot be more than {MaxLength} characters long."));
            }

            _value = value;
        }

        public string Value => _value;

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return _value;
        }

        protected virtual string GetExceptionMessage(string baseMessage)
        {
            return baseMessage;
        }
    }
}