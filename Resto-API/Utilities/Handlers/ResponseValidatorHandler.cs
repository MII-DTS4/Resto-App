﻿using System.Net;

namespace Resto_API.Utilities.Handlers
{
    public class ResponseValidatorHandler
    {
        public int Code { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public Object? Error { get; set; }

        public ResponseValidatorHandler(Object error)
        {
            Code = StatusCodes.Status400BadRequest;
            Status = HttpStatusCode.BadRequest.ToString();
            Message = "Validation Error";
            Error = error;
        }
    }
}
