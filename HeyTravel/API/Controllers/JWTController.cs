using API.Functions;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers
{    
    [ApiController]
    [Route("[controller]")]
    public class JWTController : Controller
    {
        private readonly IJWTRepository JWTrepository;
        public JWTController(IJWTRepository JWTrepository)
        {
            this.JWTrepository = JWTrepository;
        }
       
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserModel userModel)
        {
            var token = JWTrepository.Authenticate(userModel.UserName, userModel.Password);
            
            if (token == null)
                return Unauthorized();

            return Ok(token);
        }
    }
}
