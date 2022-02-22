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

        public async Task<string> Login()
        {
            var user = new UserLoginRequest { Username = "HeyTravel", Password = "HeyTravel2022!" };
            var result = await httpClient.PostAsJsonAsync<UserLoginRequest>(@$"JWT/Login", user);
            var b = await result.Content.ReadAsStringAsync();
            return b;
        }
    }
}
