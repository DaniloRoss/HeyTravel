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
        public string mesePartenza { get; set; }

        [BindProperty]
        public string meseArrivo { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            return RedirectToPage("/Risultato", new { mesepartenza = mesePartenza, mesearrivo = meseArrivo });
        }
    }
}
