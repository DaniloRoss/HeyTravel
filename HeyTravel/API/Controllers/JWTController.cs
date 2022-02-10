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

        private readonly ITokenManager tokenManager;

        public JWTController(UserManager<IdentityUser> userManager, IOptionsMonitor<JwtConfig> optionsMonitor, ITokenManager tokenManager)
        {
            _usermanager = userManager;
            _jwtConfig = optionsMonitor.CurrentValue;
            this.tokenManager = tokenManager;
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
                    var jwtToken = GenerateJwtToken(newUser);
                    await tokenManager.SetToken(userModel.Username, jwtToken);
                    return Ok(new RegistrationResponse()
                    {
                        Success = true,
                        Token = jwtToken                        
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

        [HttpGet("Login")]
        public async Task<string> Login([FromBody] UserLoginRequest user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _usermanager.FindByNameAsync(user.Username);
                if (existingUser == null)
                {
                    return "Username inesistente";        
                }
                var isCorrect = await _usermanager.CheckPasswordAsync(existingUser, user.Password);

                if (!isCorrect)
                {
                    return "Password non valida";
                }

                var jwtToken = await tokenManager.GetToken(user.Username);


                return jwtToken.Token;
            }
            return "Errore";
        }

        private string GenerateJwtToken(IdentityUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

            var jwtTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }
                ),
                //Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtTokenHandler.CreateToken(jwtTokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }
    }
}
