using NursingHome.Application.Common.Resources;

namespace NursingHome.Application.Common.Exceptions;

public class ForbiddenAccessException : Exception
{
    public ForbiddenAccessException() : base(Resource.Forbidden) { }

    public ForbiddenAccessException(string message) : base(message) { }
}
