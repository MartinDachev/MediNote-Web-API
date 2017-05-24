using MediNote.ErrorCodes;
using MediNote.ErrorResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace MediNote.Errors
{
    public class BadRequestWithHttpError : IHttpActionResult
    {
        private HttpRequestMessage request;
        private HttpError httpError;

        public BadRequestWithHttpError(HttpRequestMessage request, HttpError httpError)
        {
            this.request = request;
            this.httpError = httpError;
        }

        public BadRequestWithHttpError(HttpRequestMessage request, string message, ErrorCode errorCode)
        {
            this.request = request;
            this.httpError = new HttpError();
            this.httpError.Add("CustomErrorCode", (int)errorCode);
            this.httpError.Add("Message", message);
        }

        public BadRequestWithHttpError(HttpRequestMessage request, ErrorCode errorCode)
        {
            this.request = request;
            this.httpError = new HttpError();
            this.httpError.Add("CustomErrorCode", (int)errorCode);
            this.httpError.Add("Message", ErrorStringContainer.GetStringError(errorCode));
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = request.CreateErrorResponse(HttpStatusCode.BadRequest, httpError);
            return Task.FromResult(response);
        }
    }
}