using API.Models.DTO.Requests;
using API.Models.DTO.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyTravel.Service
{
    public interface IJWTRepository
    {
        Task<string> Login();
    }
}
