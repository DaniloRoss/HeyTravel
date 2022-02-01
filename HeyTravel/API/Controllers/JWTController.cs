using API.Configuration;
using API.Functions;
using API.Models;
using API.Models.DTO.Requests;
using API.Models.DTO.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers
{    
    [ApiController]
    [Route("[controller]")]
    public class JWTController : ControllerBase
    {
        private readonly UserManager<IdentityUser>  _usermanager;

        private readonly JwtConfig _jwtConfig;

        private readonly IJWTRepository JWTrepository;
        public JWTController(IJWTRepository JWTrepository, UserManager<IdentityUser> userManager, IOptionsMonitor<JwtConfig> optionsMonitor)
        {
            this.JWTrepository = JWTrepository;
            _usermanager = userManager;
            _jwtConfig = optionsMonitor.CurrentValue;
        }
       
        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationDTO userModel)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _usermanager.FindByNameAsync(userModel.Email);
                if (existingUser != null)
                {
                    return BadRequest(new RegistrationResponse()
                    {
                        Errors = new List<string>()
                {
                    "Email already in use"
                },
                        Success = false
                    });
                }
                var newUser = new IdentityUser() { Email = userModel.Email, UserName = userModel.Username };
                var isCreated = await _usermanager.CreateAsync(newUser, userModel.Password);

                if (isCreated.Succeeded)
                {
                    var jwtToken = JWTRepository.GenerateJwtToken(newUser, _jwtConfig);
                    return Ok(new RegistrationResponse()
                    {
                        Success = true,
                        Token=jwtToken
                    });
                }
                else
                {
                    return BadRequest(new RegistrationResponse()
                    {
                        Errors = isCreated.Errors.Select(x=> x.Description).ToList(),
                        Success = false
                    });
                }
            }

            return BadRequest(new RegistrationResponse()
            {
                Errors = new List<string>()
                {
                    "Invalid payload"
                },
                Success = false
            });
        }
        
    }
}
