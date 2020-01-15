using Authentication.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Infrastructure.Middleware
{
    public class ExceptionMiddleware
    {
        RequestDelegate next;
        public ExceptionMiddleware(RequestDelegate _next)
        {
            next = _next;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            try
            {
                await next(context);
            }
            catch (BusinessException ex)
            {
                //Loglama vs 
            }
            catch (Exception ex)
            {
                //Loglama vs 
            }


        }
    }
}
