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
    [Authorize]    
    public class PreferitiModel : PageModel
    {
        private readonly AppDbContext _context;
        public PreferitiModel(AppDbContext context)
        {
            _context = context;
            eleViaggi = _context.Viaggio.ToList();
            eleAssociazioni = _context.eleAssociazione.ToList();
        }
        public List<Viaggi> eleViaggi { get; set; }
        public List<Viaggi> eleViaggiUtente { get; set; }
        public List<Associazione> eleAssociazioniUtente { get; set; }
        public List<Associazione> eleAssociazioni { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            eleAssociazioniUtente = eleAssociazioni.Where(p => p.Username_Utente == User.Identity.Name).ToList();
            foreach (var associa in eleAssociazioniUtente)
            {
                eleViaggiUtente = eleViaggi.Where(p => p.ID == associa.ID_Viaggio).ToList();
            }
            if (eleViaggiUtente == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
                return NotFound();

            var Viaggio = _context.Viaggio.FirstOrDefault(p => p.ID == id);
            var Associazione = _context.eleAssociazione.FirstOrDefault(p => p.ID_Viaggio == id);

            _context.Viaggio.Remove(Viaggio);
            _context.eleAssociazione.Remove(Associazione);

            try
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("/Index");
            }
            catch
            {
                return RedirectToPage("/Error");
            }
        }
    }
}
