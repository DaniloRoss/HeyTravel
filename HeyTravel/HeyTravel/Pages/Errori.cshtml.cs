using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HeyTravel.Pages
{
    public class ErroriModel : PageModel
    {
        public async Task<IActionResult> OnPostAsync()
        {
            return RedirectToPage("/Index");
        }
    }
}
