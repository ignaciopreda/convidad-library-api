using System;
using System.Net;

namespace LibraryCommon.Handlers.ErrorHandling
{
    public class ExternalServiceException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        public ExternalServiceException(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        public ExternalServiceException(string message, Exception innerException = null)
            : base(message, innerException)
        {
        }
    }
}
