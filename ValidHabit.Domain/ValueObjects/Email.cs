using System.ComponentModel.DataAnnotations;
using ValidHabit.Domain.Exceptions;
using ValidHabit.Domain.Primitives;

namespace ValidHabit.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public string Value { get; }

        private Email(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new InvalidEmailException("Email cannot be empty or null.", nameof(value));
            }

            if (!new EmailAddressAttribute().IsValid(value))
            {
                throw new InvalidEmailException("Invalid email format.", nameof(value));
            }

            Value = value;
        }

        public static Email Create(string value)
        {
            return new Email(value);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
