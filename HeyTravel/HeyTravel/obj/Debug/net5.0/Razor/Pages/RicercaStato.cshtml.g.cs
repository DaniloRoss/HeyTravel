#pragma checksum "C:\Users\danil\Documents\GitHub\HeyTravel\HeyTravel\HeyTravel\Pages\RicercaStato.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "855ffeb5842b2f2b9b6284434ee8eb8afe6a4854"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(HeyTravel.Pages.Pages_RicercaStato), @"mvc.1.0.razor-page", @"/Pages/RicercaStato.cshtml")]
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
#line 1 "C:\Users\danil\Documents\GitHub\HeyTravel\HeyTravel\HeyTravel\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\danil\Documents\GitHub\HeyTravel\HeyTravel\HeyTravel\Pages\_ViewImports.cshtml"
using HeyTravel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\danil\Documents\GitHub\HeyTravel\HeyTravel\HeyTravel\Pages\_ViewImports.cshtml"
using HeyTravel.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"855ffeb5842b2f2b9b6284434ee8eb8afe6a4854", @"/Pages/RicercaStato.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a03b074e5267366dcf1d15da83fa2936236c39a7", @"/Pages/_ViewImports.cshtml")]
    public class Pages_RicercaStato : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control me-2"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("search"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("placeholder", new global::Microsoft.AspNetCore.Html.HtmlString("Search"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("aria-label", new global::Microsoft.AspNetCore.Html.HtmlString("Search"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\danil\Documents\GitHub\HeyTravel\HeyTravel\HeyTravel\Pages\RicercaStato.cshtml"
  
    ViewData["Title"] = "Stato";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<style>
    body, html {
        height: 100%;
        /* The image used */
        background-image: url(""../images/HeyTravel_Foto_Home.jpg"");
        /* Center and scale the image nicely */
        background-position: center;
        background-repeat: no-repeat;
        background-size: cover;
    }
</style>

<div class=""text-center"">
    <br />
    <br />
    <h1 class=""text-black-50""><i>Risultati del tuo stato di destinazione</i></h1>
    <br />
    <br />
</div>

<h5 class=""text-black-50"" align=""center""><i>Inserire la città di destinazione</i></h5>
");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "855ffeb5842b2f2b9b6284434ee8eb8afe6a48545637", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 28 "C:\Users\danil\Documents\GitHub\HeyTravel\HeyTravel\HeyTravel\Pages\RicercaStato.cshtml"
     foreach (var item in Model.eleCittaArrivo)
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "855ffeb5842b2f2b9b6284434ee8eb8afe6a48546165", async() => {
                    WriteLiteral("\r\n            ");
#nullable restore
#line 31 "C:\Users\danil\Documents\GitHub\HeyTravel\HeyTravel\HeyTravel\Pages\RicercaStato.cshtml"
       Write(item.name.ToString());

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n        ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 33 "C:\Users\danil\Documents\GitHub\HeyTravel\HeyTravel\HeyTravel\Pages\RicercaStato.cshtml"
    }

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
#nullable restore
#line 27 "C:\Users\danil\Documents\GitHub\HeyTravel\HeyTravel\HeyTravel\Pages\RicercaStato.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model.cittaArrivo);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<br />\r\n<div class=\"text-center\">\r\n    <h6>CASI COVID</h6>\r\n");
#nullable restore
#line 38 "C:\Users\danil\Documents\GitHub\HeyTravel\HeyTravel\HeyTravel\Pages\RicercaStato.cshtml"
     foreach (var item in Model.eleCasiArrivo)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <label class=\"text-black\"><i>Casi giornalieri: ");
#nullable restore
#line 40 "C:\Users\danil\Documents\GitHub\HeyTravel\HeyTravel\HeyTravel\Pages\RicercaStato.cshtml"
                                                   Write((int)item.CasiGiornalieri);

#line default
#line hidden
#nullable disable
            WriteLiteral(" &emsp;&emsp; &emsp;&emsp;</i></label>\r\n");
            WriteLiteral("        <label class=\"text-black\"><i>Popolazione Stato: ");
#nullable restore
#line 42 "C:\Users\danil\Documents\GitHub\HeyTravel\HeyTravel\HeyTravel\Pages\RicercaStato.cshtml"
                                                    Write((int)item.Popolazione);

#line default
#line hidden
#nullable disable
            WriteLiteral(" &emsp;&emsp; &emsp;&emsp;</i></label>\r\n");
            WriteLiteral("        <label class=\"text-black\"><i>Casi COVID attivi: ");
#nullable restore
#line 44 "C:\Users\danil\Documents\GitHub\HeyTravel\HeyTravel\HeyTravel\Pages\RicercaStato.cshtml"
                                                    Write((int)item.CasiAttivi);

#line default
#line hidden
#nullable disable
            WriteLiteral(" &emsp;&emsp; &emsp;&emsp;</i></label>\r\n");
            WriteLiteral("        <label class=\"text-black\"><i>Percentuale contagi: ");
#nullable restore
#line 46 "C:\Users\danil\Documents\GitHub\HeyTravel\HeyTravel\HeyTravel\Pages\RicercaStato.cshtml"
                                                      Write((int)item.PercentualeContagi);

#line default
#line hidden
#nullable disable
            WriteLiteral("%</i></label>\r\n");
#nullable restore
#line 47 "C:\Users\danil\Documents\GitHub\HeyTravel\HeyTravel\HeyTravel\Pages\RicercaStato.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n<br />\r\n<div class=\"text-center\">\r\n    <h6>VACCINI</h6>\r\n\r\n    <label class=\"text-black\"><i>Vaccinati: ");
#nullable restore
#line 53 "C:\Users\danil\Documents\GitHub\HeyTravel\HeyTravel\HeyTravel\Pages\RicercaStato.cshtml"
                                        Write((int)Model.eleVaccini.Vaccinati);

#line default
#line hidden
#nullable disable
            WriteLiteral(" &emsp;&emsp; &emsp;&emsp;</i></label>\r\n\r\n");
            WriteLiteral("\r\n    <label class=\"text-black\"><i>Percentuale vaccini: ");
#nullable restore
#line 59 "C:\Users\danil\Documents\GitHub\HeyTravel\HeyTravel\HeyTravel\Pages\RicercaStato.cshtml"
                                                  Write((int)Model.eleVaccini.PercentualeVaccini);

#line default
#line hidden
#nullable disable
            WriteLiteral("%</i></label>\r\n</div>\r\n<br />\r\n<div class=\"text-center\">\r\n    <input type=\"button\" onclick=\"location.href=\'RicercaData\'\" class=\"btn btn-outline-primary\" align=\"center\" value=\"Cerca\" />\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HeyTravel.Pages.RicercaStatoModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<HeyTravel.Pages.RicercaStatoModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<HeyTravel.Pages.RicercaStatoModel>)PageContext?.ViewData;
        public HeyTravel.Pages.RicercaStatoModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
