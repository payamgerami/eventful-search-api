using System;

namespace Eventful.Common.Exceptions
{
    public class InternalApiBadRequestException : Exception
    {
        public InternalApiBadRequestException(string message) : base(message) { }
    }
}