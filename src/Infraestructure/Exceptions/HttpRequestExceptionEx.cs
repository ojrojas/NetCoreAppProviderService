using System.Net;
using System.Net.Http;

namespace Cinte.Infraestructure.Exceptions
{
    public class HttpRequestExceptionEx: HttpRequestException
    {
        public HttpStatusCode HttpCode { get; }
        public HttpRequestExceptionEx(HttpStatusCode code) : this(code, null, null)
        {
        }

        public HttpRequestExceptionEx(HttpStatusCode code, string message) : this(code, message, null)
        {
        }

        public HttpRequestExceptionEx(HttpStatusCode code, string message, System.Exception inner) : base(message,
            inner)
        {
            HttpCode = code;
        }

    }
}