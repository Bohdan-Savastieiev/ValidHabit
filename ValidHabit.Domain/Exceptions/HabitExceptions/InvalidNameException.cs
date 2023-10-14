namespace ValidHabit.Domain.Exceptions.HabitExceptions
{
    public class InvalidNameException : DomainException
    {
        public InvalidNameException(string message) : base(message) { }
    }
}