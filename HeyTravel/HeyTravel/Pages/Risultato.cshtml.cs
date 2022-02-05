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
        [Inject]
        public IJWTRepository JwtRepository { get; set; }
        [Inject]
        public IScrapingRepository scrapingRepository { get; set; }

        public RisultatoModel(IJWTRepository JwtRepository, IScrapingRepository scrapingRepository)
        {
            this.JwtRepository = JwtRepository;
            this.scrapingRepository = scrapingRepository;
        }

        [BindProperty]
        public UserRegistrationDTO userRegistrationDTO { get; set; }


        public async Task<IActionResult> OnGetAsync()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var a = await JwtRepository.Register(userRegistrationDTO);
            //var a = await scrapingRepository.DataCovid("Italia");
            return Page();
        }
    }
}
