using Authentication.Common.Constants;
using Authentication.Common.DTO;
using Authentication.Common.Enum;
using Authentication.Common.Exceptions;
using Authentication.Common.Security;
using Authentication.Domain.Manager;
using Authentication.Domain.Repository.Uow;
using Authentication.Domain.Token;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Authentication.Infrastructure.Middleware
{
    public class AuthhorizationMiddleware
    {
        RequestDelegate next;
        private readonly TokenOptions tokenOpt;
        public AuthhorizationMiddleware(RequestDelegate _next, IOptions<TokenOptions> _tokenOpt)
        {
            next = _next;
            this.tokenOpt = _tokenOpt.Value;
        }

        public async Task InvokeAsync(HttpContext context, IUnitOfWork uow)
        {
            context.Request.EnableBuffering();
            using (var reader = new StreamReader(context.Request.Body))
            {
                string path = context.Request.Path;
                if (path.Contains("api"))
                {
                    var body = await reader.ReadToEndAsync();
                    var ControllerRoute = path.Remove(path.IndexOf('/'), path.LastIndexOf('/') + 1);
                    RequestDTOBase request = Newtonsoft.Json.JsonConvert.DeserializeObject<RequestDTOBase>(body);
                    if (request == null || request.RequestInfo == null || request.RequestInfo.ApplicationId < 1 || String.IsNullOrEmpty(request.RequestInfo.ClientCode) || String.IsNullOrEmpty(request.RequestInfo.ClientPassword))
                        throw new BusinessException(ResponseCode.ApplicationNotAuthorized);

                    if (!String.IsNullOrEmpty(request.RequestInfo.ClientCode) && request.RequestInfo.ApplicationId > 0)
                    {
                        var app = uow.Application.GetApplicationByClientCode(request.RequestInfo.ApplicationId);
                        if (app == null)
                            throw new BusinessException(ResponseCode.ApplicationNotAuthorized);

                        var user = await uow.User.GetAsync(x => x.UserName == request.RequestInfo.ClientCode && x.UserType == UserType.Application);

                        if (user == null)
                            throw new BusinessException(ResponseCode.ApplicationNotAuthorized);

                        var userApp = await uow.UserApplication.GetAsync(x => x.UserId == user.Id && x.ApplicationId == app.Id);

                        if (userApp == null)
                            throw new BusinessException(ResponseCode.ApplicationNotAuthorized);


                        if (!String.IsNullOrEmpty(request.RequestInfo.ClientPassword) && !String.IsNullOrEmpty(user.PasswordSalt) && HashHelper.GetDecryptedString(user.Password, user.PasswordSalt) != request.RequestInfo.ClientPassword)
                            throw new BusinessException(ResponseCode.ApplicationNotAuthorized);


                        if (!String.IsNullOrEmpty(context.Request.Headers["Authorization"]))
                        {
                            var accesstoken = context.Request.Headers["Authorization"].ToString().Remove(0, 7);
                            var handler = new JwtSecurityTokenHandler();
                            var tokenreaded = handler.ReadJwtToken(accesstoken);
                            var userid = Convert.ToInt64(tokenreaded.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
                            var userName = tokenreaded.Claims.First(x => x.Type == ClaimTypes.Name).Value;

                    
                            var userPermission = uow.UserRole.HasPermission(userid, ControllerRoute);

                            if (!userPermission)
                                throw new BusinessException(ResponseCode.PermissionNotFound);

                            UserManager.ActiveUserId = userid;
                            UserManager.ActiveUserName = userName;

                        }

                    }
                    else
                        throw new BusinessException(ResponseCode.ApplicationNotAuthorized);
                    context.Request.Body.Position = 0;
                }
                await next(context);
            }
        }

    }
}