using System;
using System.Runtime.Serialization;

namespace A10
{
    [Serializable]
    internal class IndexOutOfBoundsException : Exception
    {
        public IndexOutOfBoundsException()
        {
        }

        public IndexOutOfBoundsException(string message) : base(message)
        {
        }

        public IndexOutOfBoundsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected IndexOutOfBoundsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}