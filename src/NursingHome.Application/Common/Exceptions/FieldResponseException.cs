namespace NursingHome.Application.Common.Exceptions;
public class FieldResponseException : Exception
{
    public int StatusCode { get; }

    public FieldResponseException(int statusCode)
    {
        StatusCode = statusCode;
    }

    public FieldResponseException(int statusCode, string message) : base(message)
    {
        StatusCode = statusCode;
    }

    public FieldResponseException(int statusCode, string message, Exception innerException) : base(message, innerException)
    {
        StatusCode = statusCode;
    }
}

