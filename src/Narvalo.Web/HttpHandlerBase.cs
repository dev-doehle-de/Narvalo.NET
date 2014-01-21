﻿namespace Narvalo.Web
{
    using System.Net;
    using System.Web;
    using System.Web.Mvc;

    public abstract class HttpHandlerBase : IHttpHandler
    {
        protected HttpHandlerBase() { }

        public virtual bool IsReusable { get { return false; } }

        protected abstract HttpVerbs AcceptedVerbs { get; }

        protected virtual bool TrySkipIisCustomErrors { get { return true; } }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.TrySkipIisCustomErrors = TrySkipIisCustomErrors;

            var httpMethod = context.Request.HttpMethod;

            if (ValidateHttpMethod(httpMethod)) {
                ProcessRequestCore(context);
            }
            else {
                HandleInvalidHttpMethod(context);
            }
        }

        protected abstract void ProcessRequestCore(HttpContext context);

        protected virtual bool ValidateHttpMethod(string httpMethod)
        {
            DebugCheck.NotNullOrEmpty(httpMethod);

            return AcceptedVerbs.Contains(httpMethod);
        }

        protected virtual void HandleInvalidHttpMethod(HttpContext context)
        {
            DebugCheck.NotNull(context);

            var response = context.Response;

            // TODO: Indiquer les méthodes autorisées dans la réponse.
            response.SetStatusCode(HttpStatusCode.MethodNotAllowed);
            response.Write(Format.CurrentCulture(SR.HttpHandlerBase_InvalidHttpMethodFormat, context.Request.HttpMethod));
        }
    }
}
