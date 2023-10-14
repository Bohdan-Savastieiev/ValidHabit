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
        public string Value { get; }

        private Name()
        {
            // Required by EF Core
        }
        protected Name(string value, string nameType = "Name")
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new InvalidNameException($"{nameType} is empty.");
            }

            if (value.Length > MaxLength)
            {
                throw new InvalidNameException($"{nameType} cannot be more than {MaxLength} characters long.");
            }

            Value = value;
        }

        public static Name Create(string value)
        {
            return new Name(value);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}