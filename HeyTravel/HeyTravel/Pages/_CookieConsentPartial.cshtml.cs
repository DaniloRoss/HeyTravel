using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeyTravel.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http.Features;

namespace HeyTravel.Pages
{
    public class _CookieConsentPartialModel : PageModel
    {
        private readonly ApplicationDbContext Context;

        public _CookieConsentPartialModel(ApplicationDbContext context)
        {
            Context = context;
        }

        public void OnGet()
        {

        }
    }
}
