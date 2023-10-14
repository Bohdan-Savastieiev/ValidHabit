namespace ValidHabit.Application.Utilities
{
    public class Result<T> : Result
    {
        public T Value { get; private set; }

        private Result(T value, bool isSuccess, string errorMessage) : base(isSuccess, errorMessage)
        {
            Value = value;
        }

        public new static Result<T> Success(T value) => new Result<T>(value, true, null);

        public new static Result<T> Failure(string errorMessage) => new Result<T>(default, false, errorMessage);
    }
}