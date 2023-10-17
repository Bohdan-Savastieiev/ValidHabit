namespace ValidHabit.Domain.ValueObjects
{
    public class FirstName : Name
    {
        private FirstName(string value) : base(value, "First Name") { }

        public static new FirstName Create(string value)
        {
            return new FirstName(value);
        }
    }
}