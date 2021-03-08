using IdentityRepository.Interfaces;
using IdentityRepository.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost, Route("Authenticate")]
        public IActionResult Login(Login user)
        {
            Login loginResponse = _loginService.AuthenticateUser(user);
            if (loginResponse == null)
                return BadRequest(new { message = "Invalid username or password! Try again." });
            return Ok(loginResponse);
        }
    }
}
