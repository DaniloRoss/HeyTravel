#pragma checksum "C:\Users\danil\Documents\GitHub\HeyTravel\HeyTravel\HeyTravel\Pages\mappa.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fcda119007ec4227e54ba2fa2acc346d1b74d9a9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(HeyTravel.Pages.Pages_mappa), @"mvc.1.0.razor-page", @"/Pages/mappa.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fcda119007ec4227e54ba2fa2acc346d1b74d9a9", @"/Pages/mappa.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a03b074e5267366dcf1d15da83fa2936236c39a7", @"/Pages/_ViewImports.cshtml")]
    public class Pages_mappa : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div id=""map"" style=""width:1200px; height:600px; margin:auto; box-sizing:inherit;""></div>
<script>
    mapboxgl.accessToken = 'pk.eyJ1IjoiZGFueXJlZHMiLCJhIjoiY2t6bjEyamNxMDN6NzJucXVnZjZ2enM3eCJ9.ieT8jUJor2Z0q69as5-WYQ';
    var map = new mapboxgl.Map({
        container: 'map',
        style: 'mapbox://styles/danyreds/ckzmpnpey001h15oatavzcetr',
        center: [9.8, 45.75],
        zoom: 2.5
    });

    map.on('load', function () {

        map.addSource('COVID', {
            type: 'geojson',
            data: '../json/mappa.json'
        });

        map.addLayer({
            id: 'covidcases',
            type: 'fill',
            source: 'COVID',
            'paint': {
                'fill-color': ""#AA1100"",
                'fill-opacity': {
                    property: 'casi',
                    stops: [
                        [0, 0],
                        [10000, 0.15],
                        [1000000, 0.5],
                        [2000000, 0.7],
               ");
            WriteLiteral(@"         [100000000, 0.8],
                    ]
                }
            }
        });
    });

    map.on('click', 'covidcases', function (e) {
        const queryString = window.location.search;
        const urlParams = new URLSearchParams(queryString);
        var HTML = 'Country: <b>' + e.features[0].properties.name + '</b>' + ' ' + e.features[0].properties.casi + ' cases';
        new mapboxgl.Popup()
            .setLngLat(e.lngLat)
            .setHTML(HTML)
            .addTo(map);
    });

    // Change the cursor to a pointer when the mouse is over the states layer.
    map.on('mouseenter', 'covidcases', function () {
        map.getCanvas().style.cursor = 'pointer';
    });

    // Change it back to a pointer when it leaves.
    map.on('mouseleave', 'covidcases', function () {
        map.getCanvas().style.cursor = '';
    });
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HeyTravel.Pages.mappaModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<HeyTravel.Pages.mappaModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<HeyTravel.Pages.mappaModel>)PageContext?.ViewData;
        public HeyTravel.Pages.mappaModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
