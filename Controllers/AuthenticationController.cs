using hrmscloneapi.Model;
using hrmscloneapi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrmscloneapi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticateService _authenticateService;
        public AuthenticationController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;

        }
        [HttpPost]
        public IActionResult Post([FromBody] User model)
        {
            var user = _authenticateService.Authenticate(model.UserName, model.Password);
            if (user == null)
            {
                return BadRequest(new { message = "Username Or password Incorrect " });

            }
            else
            {
                return Ok(user);
            }
        }
    }
}
