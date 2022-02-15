using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models.DTO.Requests;
using HeyTravel.Service;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HeyTravel.Pages
{
    public class RisultatoModel : PageModel
    {
        private readonly IJWTRepository jWTRepository;
        public RisultatoModel(IJWTRepository jWTRepository)
        {
            this.jWTRepository = jWTRepository;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            var a = await jWTRepository.Login("HeyTravel", "HeyTravel2022!");
            return Page();
        }
    }
}
