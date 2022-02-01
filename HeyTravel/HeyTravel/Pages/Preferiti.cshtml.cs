using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeyTravel.Data;
using HeyTravel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HeyTravel.Pages
{
    //[Authorize]
    public class PreferitiModel : PageModel
    {
        private readonly AppDbContext _context;
        public PreferitiModel(AppDbContext context)
        {
            _context = context;
            NewViag = _context.Viaggio.ToList();
        }
        public List<Viaggi> NewViag { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
                return NotFound();

            var Via = _context.Viaggio.FirstOrDefault(p => p.ID == id);

            _context.Viaggio.Remove(Via);

            try
            {
                //await _context.SaveChangesAsync();
                return RedirectToPage("/Index");
            }
            catch
            {
                return RedirectToPage("/Error");
            }
        }
    }
}
