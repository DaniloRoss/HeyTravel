using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HeyTravel.Models;
using HeyTravel.Service;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HeyTravel.Pages
{

    public class RicercaDataModel : PageModel
    {
        [Inject]
        public IScrapingRepository scrapingRepository { get; set; }

        public RicercaDataModel(IScrapingRepository scrapingRepository)
        {
            this.scrapingRepository = scrapingRepository;
        }

        public List<Meteo> eleMeteo = new List<Meteo>();

        [BindProperty]
        public string citta { get; set; }

        [BindProperty]
        public string stato { get; set; }

        public async Task<IActionResult> OnGetAsync(string stato, string citta)
        {
            if (eleMeteo != null)
            {
                eleMeteo = await scrapingRepository.ExtractMeteo(stato, citta);
            }


            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            return Page();
        }
    }
}
