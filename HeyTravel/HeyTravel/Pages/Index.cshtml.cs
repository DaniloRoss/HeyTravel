using HeyTravel.Service;
using HeyTravel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyTravel.Pages
{
    public class IndexModel : PageModel
    {
        public int id = 10;
        [Inject]
        public IScrapingRepository scrapingRepository { get; set; }

        public IndexModel(IScrapingRepository scrapingRepository)
        {
            this.scrapingRepository = scrapingRepository;
        }
        public List<string> EleNazioni = new List<string>();
        [BindProperty]
        public string statoPartenza { get; set; }
        [BindProperty]
        public string statoArrivo { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            foreach (var line in System.IO.File.ReadLines("EleNaz.txt"))
            {
                EleNazioni.Add(line);
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            return RedirectToPage("/RicercaStato", new { statopartenza=statoPartenza, statoarrivo = statoArrivo });
        }
    }
}
