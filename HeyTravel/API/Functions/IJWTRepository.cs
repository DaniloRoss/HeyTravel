using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Functions
{
    public interface IJWTRepository
    {
        string Authenticate(string username, string password);
    }
}
