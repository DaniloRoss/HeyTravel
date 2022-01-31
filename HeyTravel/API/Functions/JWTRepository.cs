using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API.Functions
{
    public class JWTRepository : IJWTRepository
    {
        private readonly IDictionary<string, string> users = new Dictionary<string, string>
        {
            { "test1", "password1" },
            { "test2", "password2" }
        };
        private readonly string key;

        public JWTRepository(string key)
        {
            this.key = key;
        }

        public string Authenticate(string username, string password)
        {
            if(users.Any(u=>u.Key==username && u.Value == password))
            {
                return null;
            }

            var tokenhandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptior = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.Now,
                SigningCredentials =
                new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenhandler.CreateToken(tokenDescriptior);
            return tokenhandler.WriteToken(token);
        }
    }
}
