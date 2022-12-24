using Microsoft.AspNetCore.Http;
using EFCoreCodeFirstSample.Models;
using EFCoreCodeFirstSample.Services;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreCodeFirstSample.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private IAuthenticateService _authenticationService;

        public AuthenticationController(IAuthenticateService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        public IActionResult Post([FromBody]UserInfo userInfo)
        {
            var userToken = _authenticationService.Authenticate(userInfo.UserName, userInfo.Password);

            if(userToken == null)
            {
                return BadRequest(new { message = "Username and password notfound." });
            }

            HttpContext.Session.SetString("Token" + userInfo.UserName,userToken);
            HttpContext.Response.Cookies.Append(userInfo.UserName, userToken);

            return Ok(new { userName = userInfo.UserName,Token = userToken, Status = "Success" });
        }
    }
}
