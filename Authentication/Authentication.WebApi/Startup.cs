using Authentication.Domain;
using Authentication.Domain.Manager;
using Authentication.Domain.Token;
using Authentication.Infrastructure.DI.Installers;
using Authentication.Infrastructure.Middleware;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System;

namespace Authentication.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPersistence(Configuration);
            services.AddRepository();
            services.AddServices();
            services.AddTokens();
            services.AddControllers();

            var tokenopts = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            services.Configure<TokenOptions>(Configuration.GetSection("TokenOptions"));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(jwtopt =>
            {
                jwtopt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = tokenopts.Issuer,
                    ValidAudience = tokenopts.Audience,
                    IssuerSigningKey = SignHandler.GetSecurityKey(tokenopts.SecurityKey),
                    ClockSkew = TimeSpan.Zero
                };
            });


            Microsoft.OpenApi.Models.OpenApiInfo inf = new Microsoft.OpenApi.Models.OpenApiInfo();
            inf.Title = "Authentication API";
            inf.Description = "SWAGGER DOCUMENT";

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DomainToResponseProfile>();
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.OperationFilter<SecurityRequirementsOperationFilter>();

                c.SwaggerDoc("v1", inf);

                var xmlPath = System.AppDomain.CurrentDomain.BaseDirectory + @"Authentication.xml";
                c.IncludeXmlComments(xmlPath);

            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseExceptionMiddleWare();
            app.UseAuthorizationMiddleWare();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Authentication Api"));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
