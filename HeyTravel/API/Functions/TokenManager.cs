using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Functions
{
    public class TokenManager : ITokenManager
    {
        private readonly APIContext _context;

        public TokenManager(APIContext context)
        {
            this._context = context;
        }

        public async Task<UserToken> GetToken(string username)
        {
            var a = await _context.userTokens.FirstOrDefaultAsync(a => a.Username == username);
            return a;
        }

        public async Task<UserToken> SetToken(string username, string token)
        {
            await _context.AddAsync(new UserToken()
            { 
                Username = username,
                Token = token
            });

            await _context.SaveChangesAsync();

            return await GetToken(username);
        }
    }
}
