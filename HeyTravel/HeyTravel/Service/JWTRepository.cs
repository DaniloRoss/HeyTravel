using API.Models.DTO.Requests;
using API.Models.DTO.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace HeyTravel.Service
{
    public class JWTRepository : IJWTRepository
    {
        private readonly HttpClient httpClient;
        public JWTRepository(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<string> Login(string username , string password)
        {
            var user = new UserLoginRequest { Username = username, Password = password };
            var result = await httpClient.GetFromJsonAsync<string>(@$"JWT/Login/{user}");
            return null;
        }
    }
}
