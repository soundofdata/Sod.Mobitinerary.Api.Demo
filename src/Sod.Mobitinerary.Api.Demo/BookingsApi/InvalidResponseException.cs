using System;
using System.Runtime.Serialization;

namespace Sod.Mobitinerary.Api.Demo.BookingsApi
{
    /// <summary>
    ///     An exception to be thrown when something is going wrong with sending requests with <see cref="Client" />
    /// </summary>
    [Serializable]
    public class InvalidResponseException : Exception
    {
        public InvalidResponseException()
        {
        }

        public InvalidResponseException(string message) : base(message)
        {
        }

        public InvalidResponseException(string message, Exception inner) : base(message, inner)
        {
        }

        protected InvalidResponseException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}