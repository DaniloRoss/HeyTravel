using Microsoft.AspNetCore.Authorization;
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
        public List<string> EleNazioni = new List<string>();
        
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

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
            

            return Page();
        }
    }
}
