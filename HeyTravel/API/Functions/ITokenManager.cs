using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Functions
{
    public interface ITokenManager
    {
        Task<UserToken> GetToken(string username);

        Task<UserToken> SetToken(string username, string token);

    }
}
