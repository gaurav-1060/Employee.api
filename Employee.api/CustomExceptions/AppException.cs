namespace Employee.api.CustomExceptions
{
    public class AppException : Exception
    {
        public int StatusCode { get; }

        public AppException(string message)
            : base(message)
        {
            StatusCode = 500;
        }

        public AppException(string message, int statusCode)
            : base(message)
        {
            StatusCode = statusCode;
        }

        public AppException(string message, int statusCode, Exception innerException)
            : base(message, innerException)
        {
            StatusCode = statusCode;
        }
    }
}