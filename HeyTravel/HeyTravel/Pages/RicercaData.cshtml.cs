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

        public async Task<IActionResult> OnGetAsync(string stato, string citta)
        {
            return Page();
        }
        [BindProperty]
        public string cittaPartenza { get; set; }

        [BindProperty]
        public string cittaArrivo { get; set; }

        [BindProperty]
        public string statoPartenza { get; set; }
        [BindProperty]
        public string statoArrivo { get; set; }

        [BindProperty]
        public string mesepartenza { get; set; }

        [BindProperty]
        public string mesearrivo { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            return RedirectToPage("/Risultato", new { mesePartenza = mesepartenza.ToString(), meseArrivo = mesearrivo.ToString(), statopartenza = this.statoPartenza, statoarrivo = this.statoArrivo, cittarrivo = cittaArrivo });
        }
    }
}
