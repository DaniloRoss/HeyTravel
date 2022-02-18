using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using API.Models.DTO.Requests;
using HeyTravel.Models;
using HeyTravel.Service;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HeyTravel.Pages
{
    public class RisultatoModel : PageModel
    {
        [Inject]
        public IScrapingRepository scrapingRepository { get; set; }

        public RisultatoModel(IScrapingRepository scrapingRepository)
        {
            this.scrapingRepository = scrapingRepository;
        }

        public List<Meteo> eleMeteo = new List<Meteo>();
        public List<Citta> eleCittaPartenza = new List<Citta>();
        public List<Citta> eleCittaArrivo = new List<Citta>();
        public List<Casi> eleCasiArrivo = new List<Casi>();
        public Vaccini eleVaccini = new Vaccini();

        public List<OreSole> elesole = new List<OreSole>();
        public List<Temperature> eletemp = new List<Temperature>();
        public List<Precipitazioni> eleprec = new List<Precipitazioni>();
        public List<Mare> elemare = new List<Mare>();


        [BindProperty]
        public string cittapartenza { get; set; }

        [BindProperty]
        public string statopartenza { get; set; }

        [BindProperty]
        public string cittarrivo { get; set; }

        [BindProperty]
        public string statoarrivo { get; set; }

        [BindProperty]
        public string mesepartenza { get; set; }

        [BindProperty]
        public string mesearrivo { get; set; }

        public async Task<IActionResult> OnGetAsync(string statoarrivo, string cittarrivo)
        {
            if (eleCittaPartenza != null)
            {
                eleCittaArrivo = await scrapingRepository.ExtractBestCitiesPerCountryAsync(statoarrivo);
            }

            if (eleCittaArrivo != null)
            {
                eleCasiArrivo = await scrapingRepository.DataCovid(statoarrivo);
            }

            if (eleCasiArrivo != null)
            {
                eleVaccini = await scrapingRepository.DataVaccini(statoarrivo);
            }

            eleMeteo = await scrapingRepository.ExtractMeteo(statoarrivo, cittarrivo);

            if(eleMeteo[0].Mare != null)
            {

            }
            if (eleMeteo[0].Temperature != null)
            {

            }
            if (eleMeteo[0].Precipitazioni != null)
            {

            }
            if (eleMeteo[0].OreSole != null)
            {

            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            return Page();
        }
    }
}
