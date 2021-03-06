#pragma checksum "/home/luis/Documentos/Inter_KissEspataria/Views/Home/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "adba657aacf12ff19e8ca3fb9fe2b97efe21eba4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
namespace AspNetCore
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
#line 1 "/home/luis/Documentos/Inter_KissEspataria/Views/_ViewImports.cshtml"
using Inter_KissEspataria;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/luis/Documentos/Inter_KissEspataria/Views/_ViewImports.cshtml"
using Inter_KissEspataria.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"adba657aacf12ff19e8ca3fb9fe2b97efe21eba4", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3d8a2c61ab706e83f7934c983bbfd7851487e071", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "/home/luis/Documentos/Inter_KissEspataria/Views/Home/Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row"">

    <div class=""col-xl-6 col-md-6 mb-4"">
        <div class=""card border-left-primary shadow"">
            <div class=""card-body"">
                <div class=""row no-gutters align-items-center"">
                    <div class=""col mr-2"">
                        <div class=""text-xs font-weight-bold text-primary mb-1"">
                            Ganhos (Dia)</div>
                        <div class=""h1 mb-0 font-weight-bold text-gray-800"">");
#nullable restore
#line 14 "/home/luis/Documentos/Inter_KissEspataria/Views/Home/Index.cshtml"
                                                                       Write(ViewBag.GetComandasDia);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                    </div>
                    <div class=""col-auto"">
                        <i class=""fa fa-sun-o fa-2x"" aria-hidden=""true""></i>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class=""col-xl-6 col-md-6 mb-4"">
        <div class=""card border-left-success shadow"">
            <div class=""card-body"">
                <div class=""row no-gutters align-items-center"">
                    <div class=""col mr-2"">
                        <div class=""text-xs font-weight-bold text-primary mb-1"">
                            Ganhos (M??s)</div>
                        <div class=""h1 mb-0 font-weight-bold text-gray-800"">");
#nullable restore
#line 30 "/home/luis/Documentos/Inter_KissEspataria/Views/Home/Index.cshtml"
                                                                       Write(ViewBag.GetComandasMes);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                    </div>
                    <div class=""col-auto"">
                        <i class=""fa fa-calendar-check-o fa-2x"" aria-hidden=""true""></i>
                    </div>
                </div>
            </div>
        </div>
    </div>

");
            WriteLiteral(@"    <div class=""container-xl px-4 mt-4"">
        <div class=""card mb-4"">
            <div class=""card-header"">Comandas</div>
            <div class=""card-body p-0"">
                <!-- Billing history table-->
                <div class=""table-responsive table-billing-history"">
                    <table class=""table mb-0"">
                        <thead>
                            <tr>
                                <th class=""border-gray-200"" scope=""col"">Id</th>
                                <th class=""border-gray-200"" scope=""col"">Emiss??o</th>
                                <th class=""border-gray-200"" scope=""col"">Atendente</th>
                                <th class=""border-gray-200"" scope=""col"">Gar??om</th>
                                <th class=""border-gray-200"" scope=""col"">Total</th>
                                <th class=""border-gray-200"" scope=""col"">Status</th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 59 "/home/luis/Documentos/Inter_KissEspataria/Views/Home/Index.cshtml"
                             foreach (var comanda in @ViewBag.Comandas)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td>");
#nullable restore
#line 62 "/home/luis/Documentos/Inter_KissEspataria/Views/Home/Index.cshtml"
                                   Write(comanda.ComandaId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 63 "/home/luis/Documentos/Inter_KissEspataria/Views/Home/Index.cshtml"
                                   Write(comanda.DataEmissao);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 64 "/home/luis/Documentos/Inter_KissEspataria/Views/Home/Index.cshtml"
                                   Write(comanda.Atendente);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 65 "/home/luis/Documentos/Inter_KissEspataria/Views/Home/Index.cshtml"
                                   Write(comanda.Garcon);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 66 "/home/luis/Documentos/Inter_KissEspataria/Views/Home/Index.cshtml"
                                   Write(comanda.valorTotal);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 67 "/home/luis/Documentos/Inter_KissEspataria/Views/Home/Index.cshtml"
                                     if (comanda.Status == "Encerrado")
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <td><span class=\"badge bg-danger\">");
#nullable restore
#line 69 "/home/luis/Documentos/Inter_KissEspataria/Views/Home/Index.cshtml"
                                                                     Write(comanda.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></td>\r\n");
#nullable restore
#line 70 "/home/luis/Documentos/Inter_KissEspataria/Views/Home/Index.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <td><span class=\"badge bg-success\">");
#nullable restore
#line 73 "/home/luis/Documentos/Inter_KissEspataria/Views/Home/Index.cshtml"
                                                                      Write(comanda.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></td>\r\n");
#nullable restore
#line 74 "/home/luis/Documentos/Inter_KissEspataria/Views/Home/Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </tr>\r\n");
#nullable restore
#line 76 "/home/luis/Documentos/Inter_KissEspataria/Views/Home/Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n</div>\r\n");
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
