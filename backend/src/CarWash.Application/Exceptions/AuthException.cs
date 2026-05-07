namespace CarWash.Application.Exceptions;

public class AuthException : Exception
{
    public int StatusCode { get; }

    public string ErrorCode { get; }

    public AuthException(int statusCode, string errorCode, string message)
        : base(message)
    {
        StatusCode = statusCode;
        ErrorCode = errorCode;
    }

    public AuthException() : base()
    {
    }

    public AuthException(string? message) : base(message)
    {
    }

    public AuthException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
