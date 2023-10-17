namespace ValidHabit.Application.Utilities
{
    public class Result
    {
        public bool IsSuccess { get; protected set; }
        public string ErrorMessage { get; protected set; }

        protected Result(bool isSuccess, string errorMessage)
        {
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
        }

        public static Result Success() => new Result(true, null);

        public static Result Failure(string errorMessage) => new Result(false, errorMessage);
    }
}
