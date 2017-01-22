using System;

namespace Exercise.Models.Api
{
    public class NullBaseUrlException : Exception
    {
        public NullBaseUrlException()
        {

        }

        public NullBaseUrlException(string message)
        : base(message)
        {

        }

        public NullBaseUrlException(string message, Exception inner)
        : base(message, inner)
        {

        }
    }
}