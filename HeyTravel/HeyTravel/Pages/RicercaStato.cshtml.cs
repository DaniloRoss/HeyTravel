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
        public Casi eleCasiArrivo = new Casi();
        public Vaccini eleVaccini = new Vaccini();

        [BindProperty]
        public string cittaPartenza { get; set; }

        [BindProperty]
        public string cittaArrivo { get; set; }

        [BindProperty]
        public string statopartenza { get; set; }

        [BindProperty]
        public string statoarrivo { get; set; }

        public async Task<IActionResult> OnGetAsync(string statopartenza, string statoarrivo)
        {
            eleCittaPartenza =  await scrapingRepository.ExtractBestCitiesPerCountryAsync(statopartenza);

            if (eleCittaPartenza != null)
            {
                Thread.Sleep(800);
                eleCittaArrivo = await scrapingRepository.ExtractBestCitiesPerCountryAsync(statoarrivo);             
            }
       
            if (eleCasiArrivo != null)
            {
                Thread.Sleep(300);
                eleCasiArrivo = await scrapingRepository.DataCovid(statoarrivo);
            }

            if (eleVaccini != null)
            {
                Thread.Sleep(300);
                eleVaccini = await scrapingRepository.DataVaccini(statoarrivo);
            }
     
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            return Page();
        }
    }
}
