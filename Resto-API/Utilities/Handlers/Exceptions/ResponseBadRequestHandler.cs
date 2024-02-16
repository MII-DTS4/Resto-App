using System.Net;

namespace Resto_API.Utilities.Handlers.Exceptions
{
    public class ResponseBadRequestHandler : ResponseErrorHandler
    {
        public ResponseBadRequestHandler(string message)
        {
            Code = StatusCodes.Status400BadRequest;
            Status = HttpStatusCode.BadRequest.ToString();
            Message = message;
        }
    }
}
