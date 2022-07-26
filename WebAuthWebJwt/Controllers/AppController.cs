using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAuthWebJwt.Models;
namespace WebAuthWebJwt.Controllers
{
    [Authorize]
    public class AppController : ApiController
    {
        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login(LoginRequest request)
        {
            if(request?.UserName=="admin" && request?.Password=="admin")
            {
                var token = JwtHelper.CreateJwtToken(request);
                return Ok(new { success = true, jwt = token });

            }
            return Ok(new { success = false, msg = "Invalid creds." });
        }

        [HttpGet]
        [Route("home")]
        public IHttpActionResult Home()
        {
            return Ok("home");
        }
    }
}
