using System.Net;

namespace Resto_API.Utilities.Handlers.Exceptions
{
    //kelas khusus untuk response error internal server
    public class ResponseInternalServerErrorHandler : ResponseErrorHandler
    {
        public ResponseInternalServerErrorHandler(string message, string error) {
            Code = StatusCodes.Status500InternalServerError;
            Status = HttpStatusCode.InternalServerError.ToString();
            Message = message;
            Error = error;
        }
    }
}
