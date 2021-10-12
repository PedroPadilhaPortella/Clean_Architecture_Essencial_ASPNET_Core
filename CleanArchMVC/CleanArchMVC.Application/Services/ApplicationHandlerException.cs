using System;
using System.Runtime.Serialization;

namespace CleanArchMVC.Application.Services
{
    [Serializable]
    internal class ApplicationHandlerException : Exception
    {
        public ApplicationHandlerException()
        {
        }

        public ApplicationHandlerException(string message) : base(message)
        {
        }

        public ApplicationHandlerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ApplicationHandlerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}