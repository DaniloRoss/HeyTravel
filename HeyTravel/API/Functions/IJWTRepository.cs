using API.Configuration;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Functions
{
    public interface IJWTRepository
    {
        public string GenerateJwtToken(IdentityUser user, JwtConfig _jwtConfig);
    }
}
