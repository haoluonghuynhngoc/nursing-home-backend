using NursingHome.Application.Common.Resources;
using NursingHome.Shared.Extensions;

namespace NursingHome.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base(Resource.NotFound) { }

        public NotFoundException(string message) : base(message) { }

        public NotFoundException(string message, Exception innerException) : base(message, innerException) { }

        public NotFoundException(string name, object key)
            : base(Resource.EntityNotFound.Format(name, key)) { }
    }
}
