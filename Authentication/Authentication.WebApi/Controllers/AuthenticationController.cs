using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authentication.Application.Services;
using Authentication.Domain.Dto.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Authentication.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService AuthenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            this.AuthenticationService = authenticationService;
        }

        [HttpPost]
        [Route("/api/v1/InsertUserAsync")]
        public async Task<InsertUserResponseDTO> InsertUserAsync(InsertUserRequestDTO request)
        {
            return await AuthenticationService.InsertUserAsync(request);
        }

        [HttpPost]
        [Route("/api/v1/ValidateUserAsync")]
        public async Task<ValidateUserResponseDTO> ValidateUserAsync(ValidateUserRequestDTO request)
        {
            return await AuthenticationService.ValidateUserAsync(request);
        }

        [Authorize]
        [HttpPost]
        [Route("/api/v1/GetUsers")]
        public GetUserListResponseDTO GetUsers(GetUserRequestDTO request)
        {
            return AuthenticationService.GetUsers(request);
        }
    }
}
