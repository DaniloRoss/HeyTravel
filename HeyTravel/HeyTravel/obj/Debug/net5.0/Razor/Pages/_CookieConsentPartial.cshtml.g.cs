#pragma checksum "C:\Users\infol\Desktop\School\Informatica\GitHub\MILESTONE MS-4.1\MILESTONE-MS-4.1\MILESTONE MS-4.1\HeyTravel\HeyTravel\HeyTravel\Pages\_CookieConsentPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "837c492d3c2e55ccdf8d98850101f81eefb7f21d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(HeyTravel.Pages.Pages__CookieConsentPartial), @"mvc.1.0.view", @"/Pages/_CookieConsentPartial.cshtml")]
namespace HeyTravel.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\infol\Desktop\School\Informatica\GitHub\MILESTONE MS-4.1\MILESTONE-MS-4.1\MILESTONE MS-4.1\HeyTravel\HeyTravel\HeyTravel\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\infol\Desktop\School\Informatica\GitHub\MILESTONE MS-4.1\MILESTONE-MS-4.1\MILESTONE MS-4.1\HeyTravel\HeyTravel\HeyTravel\Pages\_ViewImports.cshtml"
using HeyTravel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\infol\Desktop\School\Informatica\GitHub\MILESTONE MS-4.1\MILESTONE-MS-4.1\MILESTONE MS-4.1\HeyTravel\HeyTravel\HeyTravel\Pages\_ViewImports.cshtml"
using HeyTravel.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\infol\Desktop\School\Informatica\GitHub\MILESTONE MS-4.1\MILESTONE-MS-4.1\MILESTONE MS-4.1\HeyTravel\HeyTravel\HeyTravel\Pages\_CookieConsentPartial.cshtml"
using Microsoft.AspNetCore.Http.Features;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"837c492d3c2e55ccdf8d98850101f81eefb7f21d", @"/Pages/_CookieConsentPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a03b074e5267366dcf1d15da83fa2936236c39a7", @"/Pages/_ViewImports.cshtml")]
    public class Pages__CookieConsentPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\infol\Desktop\School\Informatica\GitHub\MILESTONE MS-4.1\MILESTONE-MS-4.1\MILESTONE MS-4.1\HeyTravel\HeyTravel\HeyTravel\Pages\_CookieConsentPartial.cshtml"
  
    var consentFeature = Context.Features.Get<ITrackingConsentFeature>();
    var showBanner = !consentFeature?.CanTrack ?? false;
    var cookieString = consentFeature?.CreateConsentCookie();

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\infol\Desktop\School\Informatica\GitHub\MILESTONE MS-4.1\MILESTONE-MS-4.1\MILESTONE MS-4.1\HeyTravel\HeyTravel\HeyTravel\Pages\_CookieConsentPartial.cshtml"
 if (showBanner)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div id=""cookieConsent"" class=""alert alert-info alert-dismissible fade show"" role=""alert"" align=""center"">
        Accetta tutti i Cookie
        <button type=""button"" class=""accept-policy close"" data-dismiss=""alert"" aria-label=""Close"" data-cookie-string=""");
#nullable restore
#line 11 "C:\Users\infol\Desktop\School\Informatica\GitHub\MILESTONE MS-4.1\MILESTONE-MS-4.1\MILESTONE MS-4.1\HeyTravel\HeyTravel\HeyTravel\Pages\_CookieConsentPartial.cshtml"
                                                                                                                 Write(cookieString);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""">
            <span aria-hidden=""true"">Accept</span>
        </button>
    </div>
    <script>
        (function () {
            var button = document.querySelector(""#cookieConsent button[data-cookie-string]"");
            button.addEventListener(""click"", function (event) {
                document.cookie = button.dataset.cookieString;
            }, false);
        })();
    </script>
");
#nullable restore
#line 23 "C:\Users\infol\Desktop\School\Informatica\GitHub\MILESTONE MS-4.1\MILESTONE-MS-4.1\MILESTONE MS-4.1\HeyTravel\HeyTravel\HeyTravel\Pages\_CookieConsentPartial.cshtml"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
