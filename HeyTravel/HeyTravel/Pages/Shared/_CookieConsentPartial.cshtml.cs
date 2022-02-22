using HeyTravel.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HeyTravel.Pages
{
    public class _CookieConsentPartialModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public _CookieConsentPartialModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {

        }
    }
}
