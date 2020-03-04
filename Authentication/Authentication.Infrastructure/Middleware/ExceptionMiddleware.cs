using Authentication.Common.Exceptions;
using Authentication.Domain.Token;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Infrastructure.Middleware
{
    public class ExceptionMiddleware
    {
        RequestDelegate next;
        private readonly TokenOptions tokenOpt;
        public ExceptionMiddleware(RequestDelegate _next, IOptions<TokenOptions> _tokenOpt)
        {
            next = _next;
            this.tokenOpt = _tokenOpt.Value;
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
