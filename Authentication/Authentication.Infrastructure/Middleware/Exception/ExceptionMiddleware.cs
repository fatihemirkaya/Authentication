using Authentication.Common.Constants;
using Authentication.Common.DTO;
using Authentication.Common.Exceptions;
using Authentication.Common.Resources;
using Authentication.Domain.Token;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Infrastructure.Middleware
{
    public class ExceptionMiddleware
    {
        RequestDelegate next;
        private readonly Func<object, Task> _clearCacheHeadersDelegate;
        public ExceptionMiddleware(RequestDelegate _next)
        {
            _clearCacheHeadersDelegate = ClearCacheHeaders;
            next = _next;

        }

        public async Task InvokeAsync(HttpContext context)
        {
            string message = "";
            try
            {
                await next(context);
            }
            catch (BusinessException ex)
            {
                await HandleAndWrapExceptionAsync(context, ex.Message, ex.ResponseCode, null, true);
            }
            catch (Exception ex)
            {
                if (context.Response.HasStarted)
                {
                    message = "An exception occurred, but response has already started!";
                }
                await HandleAndWrapExceptionAsync(context, ex.Message + message, "999", null, false);

            }


        }

        private string GetResponseMessage(string responseCode, object[] parameters)
        {
            if (responseCode == ResponseCode.Success)
            {
                return string.Empty;
            }
            ResourceManager resourceManager = new ResourceManager(typeof(ResponseMessage_en_US));
            string message = resourceManager.GetString(string.Format("RC{0}", responseCode));
            if (parameters != null)
            {
                message = string.Format(message, parameters);
            }
            return message;
        }


        private async Task WriteResponseAsync(HttpContext context, string bodyJson)
        {
            
            context.Response.Headers.Add("Accept", "application/json");
            context.Response.Headers.Add("Content-Type", "application/json");
            context.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With");
            context.Response.Headers.Add("Access-Control-Allow-Methods", "GET,POST,OPTIONS,DELETE,PUT");
            context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            byte[] data = ASCIIEncoding.ASCII.GetBytes(bodyJson);
            await context.Response.Body.WriteAsync(data, 0, data.Length);
        }

        private async Task HandleAndWrapExceptionAsync(HttpContext httpContext, string exceptionMessage, string responseCode, object[] parameters, bool business)
        {
            httpContext.Response.OnStarting(_clearCacheHeadersDelegate, httpContext.Response);
            if (business)
            {
                exceptionMessage = this.GetResponseMessage(responseCode, parameters);
            }
           
            ResponseDTOBase response = new ResponseDTOBase();
            response.responseInfo.responseCode = responseCode;
            response.responseInfo.message = exceptionMessage;
            response.responseInfo.IsSuccess = false;
            var responseJson = Newtonsoft.Json.JsonConvert.SerializeObject(response);
            await WriteResponseAsync(httpContext, responseJson);
        }

        private Task ClearCacheHeaders(object state)
        {
            var response = (HttpResponse)state;
            response.Headers[HeaderNames.CacheControl] = "no-cache";
            response.Headers[HeaderNames.Pragma] = "no-cache";
            response.Headers[HeaderNames.Expires] = "-1";
            response.Headers.Remove(HeaderNames.ETag);
            return Task.CompletedTask;
        }
    }
}