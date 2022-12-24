using EFCoreCodeFirstSample.Models;
using EFCoreCodeFirstSample.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System;

namespace EFCoreCodeFirstSample.Filters
{
    public class AuthFilter : AuthorizeAttribute, IAuthorizationFilter
    {
        IAuthenticateService _authenticateService;
        IConfiguration _config;
        public AuthFilter(IAuthenticateService authenticateService, IConfiguration config)
        {
            _authenticateService = authenticateService;
            _config = config;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var authAppsettings = _config.GetSection("Authentication");
            var appSettings = authAppsettings.Get<AppSettings>();

            string auth = context.HttpContext.Request.Headers["Authorization"].ToString();
            string token = auth != string.Empty ? auth.Split(" ")[1] : string.Empty;

            var isValid = _authenticateService.IsTokenValid(appSettings.Key, token);

            if (!isValid)
            {
                context.Result = new UnauthorizedResult();
            }

        }
    }
}
