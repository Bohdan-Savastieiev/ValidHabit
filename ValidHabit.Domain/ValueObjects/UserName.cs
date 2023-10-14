using ValidHabit.Domain.Exceptions.HabitExceptions;
using ValidHabit.Domain.Primitives;

namespace ValidHabit.Domain.ValueObjects
{
    public class Username : Name
    {
        public new const int MaxLength = 20;
        public const int MinLength = 6;

        private Username(string value) : base(value, "Username")
        {
            if (value.Length < MinLength)
            {
                throw new InvalidNameException($"Username cannot be less than {MinLength} characters long.");
            }

            if (value.Length > MaxLength)
            {
                throw new InvalidNameException($"Username cannot be more than {MaxLength} characters long.");
            }
        }

        public static new Username Create(string value)
        {
            return new Username(value);
        }
    }

}