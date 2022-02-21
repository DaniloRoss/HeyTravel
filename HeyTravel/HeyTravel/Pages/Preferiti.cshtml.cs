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
            eleViaggi = _context.eleViaggi.ToList();
            eleAssociazioni = _context.eleAssociazione.ToList();
        }
        public List<Viaggio> eleViaggi { get; set; }
        public List<Viaggio> eleViaggiUtente { get; set; }
        public List<Associazione> eleAssociazioniUtente { get; set; }
        public List<Associazione> eleAssociazioni { get; set; }        

        public async Task<IActionResult> OnGetAsync()
        {
            eleViaggiUtente = new List<Viaggio>();
            eleAssociazioniUtente = eleAssociazioni.Where(p => p.Username_Utente == User.Identity.Name).ToList();
            foreach (var associa in eleAssociazioniUtente)
            {
                var viaggio = eleViaggi.Where(p => p.ID == associa.ID_Viaggio).FirstOrDefault();
                if (viaggio != null)
                {
                    eleViaggiUtente.Add(viaggio);
                }                 
            }
            if (eleViaggiUtente == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {            
            string buttonClicked = Request.Form["SubmitButton"];
            if (buttonClicked == "visualizza") 
            {
                var Viaggio = _context.eleViaggi.FirstOrDefault(p => p.ID == id);
                ///Risultato?mesePartenza=2022-04&meseArrivo=2022-04&statoarrivo=Italia&cittarrivo=Roma
                return RedirectToPage("/Risultato", new { mesePartenza = Viaggio.MesePartenza, meseArrivo=Viaggio.MeseArrivo, statoarrivo = Viaggio.StatoArrivo, cittarrivo=Viaggio.CittaArrivo });
            }
            if (buttonClicked == "rimuovi") 
            {
                if (id == null)
                    return NotFound();

                var Viaggio = _context.eleViaggi.FirstOrDefault(p => p.ID == id);
                var Associazione = _context.eleAssociazione.FirstOrDefault(p => p.ID_Viaggio == id);

                _context.eleViaggi.Remove(Viaggio);
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
            return Page();
        }
    }
}
