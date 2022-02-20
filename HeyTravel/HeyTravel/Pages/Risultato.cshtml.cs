using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using API.Models.DTO.Requests;
using HeyTravel.Data;
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
        private readonly AppDbContext _context;
        public RisultatoModel(IScrapingRepository scrapingRepository, AppDbContext context)
        {
            this.scrapingRepository = scrapingRepository;
            _context = context;
            eleViaggi = _context.eleViaggi.ToList();

            mesi.Add(1, "Gennaio");
            mesi.Add(2, "Febbraio");
            mesi.Add(3, "Marzo");
            mesi.Add(4, "Aprile");
            mesi.Add(5, "Maggio");
            mesi.Add(6, "Giugno");
            mesi.Add(7, "Luglio");
            mesi.Add(8, "Agosto");
            mesi.Add(9, "Settembre");
            mesi.Add(10, "Ottobre");
            mesi.Add(11, "Novembre");
            mesi.Add(12, "Dicembre");
        }

        public List<Viaggio> eleViaggi { get; set; }
        public List<Associazione> eleAssociazioni { get; set; }

        public List<Meteo> eleMeteo = new List<Meteo>();
        public List<Citta> eleCittaPartenza = new List<Citta>();
        public List<Citta> eleCittaArrivo = new List<Citta>();
        public List<Casi> eleCasiArrivo = new List<Casi>();
        public Vaccini eleVaccini = new Vaccini();
        public List<string> elefoto = new List<string>();

        public List<OreSole> elesole = new List<OreSole>();
        public List<Temperature> eletemp = new List<Temperature>();
        public List<Precipitazioni> eleprec = new List<Precipitazioni>();
        public List<Mare> elemare = new List<Mare>();

        IDictionary<int, string> mesi = new Dictionary<int, string>();     
        
        [BindProperty]
        public Viaggio Viaggio { get; set; }

        [BindProperty]
        public string cittapartenza { get; set; }

        [BindProperty]
        public string statopartenza { get; set; }

        [BindProperty]
        public string cittarrivo { get; set; }

        [BindProperty]
        public string statoarrivo { get; set; }

        [BindProperty]
        public string mesePartenza { get; set; }

        [BindProperty]
        public string meseArrivo { get; set; }

        [BindProperty]
        public decimal Latitude { get; set; }

        [BindProperty]
        public decimal Longitude { get; set; }

        public async Task<IActionResult> OnGetAsync(string statoarrivo, string cittarrivo, string mesePartenza, string meseArrivo, decimal Latitude, decimal Longitude)
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

            var mpartenza = mesePartenza.Split("-")[1];

            var marrivo = meseArrivo.Split("-")[1];                                                   
            
            if(eleMeteo[0].Mare != null)
            {
                for (int i = int.Parse(mpartenza); i <= int.Parse(marrivo); i++)
                {
                    var zz = eleMeteo[0].Mare.First(a => a.Mese == mesi[i]);
                    elemare.Add(zz);
                }
            }
            if (eleMeteo[0].Temperature != null)
            {
                for (int i = int.Parse(mpartenza); i<= int.Parse(marrivo); i++)
                {
                    var zz = eleMeteo[0].Temperature.First(a => a.Mese == mesi[i]);
                    eletemp.Add(zz);
                }
            }
            if (eleMeteo[0].Precipitazioni != null)
            {
                for (int i = int.Parse(mpartenza); i <= int.Parse(marrivo); i++)
                {
                    var zz = eleMeteo[0].Precipitazioni.First(a => a.Mese == mesi[i]);
                    eleprec.Add(zz);
                }
            }
            if (eleMeteo[0].OreSole != null)
            {
                for (int i = int.Parse(mpartenza); i <= int.Parse(marrivo); i++)
                {
                    var zz = eleMeteo[0].OreSole.First(a => a.Mese == mesi[i]);
                    elesole.Add(zz);
                }
            }
            Viaggio = new Viaggio
            {
                StatoArrivo = statoarrivo,
                CittaArrivo = cittarrivo,
                MesePartenza = mesePartenza,
                MeseArrivo = meseArrivo
            };

            _context.eleViaggi.Add(Viaggio);

            elefoto = await scrapingRepository.GetImages(cittarrivo);

            this.statoarrivo = statoarrivo;
            this.cittarrivo = cittarrivo;
            this.meseArrivo = meseArrivo;
            this.mesePartenza = mesePartenza;

            try
            {
                await _context.SaveChangesAsync();
                return Page();
            }
            catch
            {
                return NotFound();
            }            
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (User != null)
            {
                Viaggio viaggio = eleViaggi.Where(p => p.ID == id).FirstOrDefault();

                if (viaggio == null)
                {
                    return NotFound();
                }

                Associazione associazione = new Associazione
                {
                    ID_Viaggio = viaggio.ID,
                    Username_Utente = User.Identity.Name
                };
                             
                _context.eleAssociazione.Add(associazione);

                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToPage("/Preferiti");
                }
                catch
                {
                    return NotFound();
                }
            }
            else
            {
                return RedirectToPage("/Account/Login");
            }
        }
    }
}
