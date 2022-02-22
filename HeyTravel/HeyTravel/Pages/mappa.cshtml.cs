using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeyTravel.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HeyTravel.Pages
{
    public class mappaModel : PageModel
    {
        private readonly IScrapingRepository iscrapingRepository;
        public mappaModel(IScrapingRepository scrapingRepository)
        {
            this.iscrapingRepository = scrapingRepository;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            await iscrapingRepository.Mappa();
            return Page();
        }
    }
}
