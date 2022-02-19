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
    public class RicercaStatoModel : PageModel
    {
        [Inject]
        public IScrapingRepository scrapingRepository { get; set; }

        public RicercaStatoModel(IScrapingRepository scrapingRepository)
        {
            this.scrapingRepository = scrapingRepository;
        }
        public List<Citta> eleCittaPartenza = new List<Citta>();
        public List<Citta> eleCittaArrivo = new List<Citta>();
        public List<Casi> eleCasiArrivo = new List<Casi>();
        public Vaccini eleVaccini = new Vaccini();

        [BindProperty]
        public string cittarrivo { get; set; }

        [BindProperty]
        public string statopartenza { get; set; }

        [BindProperty]
        public string statoarrivo { get; set; }

        public async Task<IActionResult> OnGetAsync(string statopartenza, string statoarrivo)
        {
            //eleCittaPartenza =  await scrapingRepository.ExtractBestCitiesPerCountryAsync(statopartenza);

            if (eleCittaPartenza != null)
            {
                eleCittaArrivo = await scrapingRepository.ExtractBestCitiesPerCountryAsync(statoarrivo);             
            }
     
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            return RedirectToPage("/RicercaData", new { statoPartenza = this.statopartenza, statoArrivo = this.statoarrivo, cittaArrivo = cittarrivo });
        }
    }
}
