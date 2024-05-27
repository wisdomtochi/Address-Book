namespace Address_Book.Services.Helpers
{
    public record Result
    {
        protected Result(bool status, string message)
        {
            Succeeded = status;
            Message = message;
        }

        public string Message { get; set; }
        public bool Succeeded { get; set; }
        public static Result<T> Success<T>(T Data, string message = null) => new(Data, true, message);
        public static Result Success(string message = null) => new(true, message);
        public static Result<T> Failure<T>(string message = null) => new(default(T), false, message);
        public static Result Failure(string message = null) => new(false, message);
    }

    public record Result<T> : Result
    {
        public Result(T data, bool status, string message) : base(status, message)
        {
            Data = data;
        }

        public T Data { get; set; }
    }
}
