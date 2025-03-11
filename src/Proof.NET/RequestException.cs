using System;
using System.Collections.Generic;

namespace Proof.NET
{
    public class RequestException : Exception
    {
        public RequestException(string message, Exception? innerException = null)
            : base(message, innerException) { }

        public IEnumerable<string>? Errors { get; set; }

        public required int HttpStatusCode { get; init; }
    }
}
