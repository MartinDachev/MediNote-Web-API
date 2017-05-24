using MediNote.ErrorCodes;
using MediNote.Errors;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MediNote.WebApiControllers
{
    public class BaseApiController : ApiController
    {
        #region Helpers

        protected virtual IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }

        protected virtual IHttpActionResult GetErrorResult(IdentityResult result, ErrorCode errorCode)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                var httpError = new HttpError();

                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                httpError.Add("CustomErrorCode", (int)errorCode);
                httpError.Add("ModelState", ModelState.Values.Select(x => x.Errors.Select(e => e.ErrorMessage)));

                var response = Request.CreateErrorResponse(HttpStatusCode.BadRequest, httpError);

                return ResponseMessage(response);
            }

            return null;
        }

        #endregion
    }
}
