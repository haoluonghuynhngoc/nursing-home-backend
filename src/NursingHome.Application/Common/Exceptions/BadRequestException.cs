using NursingHome.Application.Common.Resources;

namespace NursingHome.Application.Common.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException() : base(Resource.BadRequest) { }
        public BadRequestException(string message) : base(message) { }
        public BadRequestException(string message, Exception innerException) : base(message, innerException) { }
    }
}
