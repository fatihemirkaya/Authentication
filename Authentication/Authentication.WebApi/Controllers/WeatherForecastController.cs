using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authentication.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Authentication.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IAuthenticationService AuthenticationService;

        public WeatherForecastController(IAuthenticationService authenticationService)
        {
            this.AuthenticationService = authenticationService;
        }

        [HttpGet]
        public async Task<bool> Get()
        {
           return await this.AuthenticationService.InsertUser();
        }
    }
}
