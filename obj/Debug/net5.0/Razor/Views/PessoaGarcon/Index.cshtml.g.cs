#pragma checksum "/home/luis/Documentos/Inter_KissEspataria/Views/PessoaGarcon/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b95754a4c23576d3fd326a1dee30a4eb21daa22e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PessoaGarcon_Index), @"mvc.1.0.view", @"/Views/PessoaGarcon/Index.cshtml")]
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
#nullable restore
#line 2 "/home/luis/Documentos/Inter_KissEspataria/Views/PessoaGarcon/Index.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/home/luis/Documentos/Inter_KissEspataria/Views/PessoaGarcon/Index.cshtml"
using System.Text.Json;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b95754a4c23576d3fd326a1dee30a4eb21daa22e", @"/Views/PessoaGarcon/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3d8a2c61ab706e83f7934c983bbfd7851487e071", @"/Views/_ViewImports.cshtml")]
    public class Views_PessoaGarcon_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<PessoaGarcon>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<br />\r\n");
#nullable restore
#line 7 "/home/luis/Documentos/Inter_KissEspataria/Views/PessoaGarcon/Index.cshtml"
 if (Model == null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h3>");
#nullable restore
#line 9 "/home/luis/Documentos/Inter_KissEspataria/Views/PessoaGarcon/Index.cshtml"
   Write(ViewBag.Mensagem);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n");
#nullable restore
#line 10 "/home/luis/Documentos/Inter_KissEspataria/Views/PessoaGarcon/Index.cshtml"
}
else
{

    string json = HttpContextAccessor.HttpContext.Session.GetString("user");

    if (json != null)
    {
        PessoaAtendente user = JsonSerializer.Deserialize<PessoaAtendente>(json);

        if (user != null)
        {
            if (user.Admin == "TRUE")
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""container-xl px-4 mt-4"">
    <div class=""card mb-4"">
        <div class=""card-header"">Garçons</div>
        <div class=""card-body p-0"">
            <div class=""table-responsive table-billing-history"">
                <table class=""table mb-0"">
                    <thead>
                        <tr>
                            <th class=""border-gray-200"" scope=""col"">Id</th>
                            <th class=""border-gray-200"" scope=""col"">Nome</th>
                            <th class=""border-gray-200"" scope=""col"">CPF</th>
                            <th class=""border-gray-200"" scope=""col"">Telefone</th>
                            <th class=""border-gray-200"" scope=""col"">Salario</th>
                            <th class=""border-gray-200"" scope=""col"">Comissão</th>
                            <th class=""border-gray-200"" scope=""col"">Regime Trab.</th>
                            <th class=""border-gray-200"" scope=""col"">Ativo</th>
                        </tr>
       ");
            WriteLiteral("             </thead>\r\n                    <tbody>\r\n");
#nullable restore
#line 43 "/home/luis/Documentos/Inter_KissEspataria/Views/PessoaGarcon/Index.cshtml"
                         foreach (var garcon in Model)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tbody>\r\n                                            <tr>\r\n                                                <td>");
#nullable restore
#line 47 "/home/luis/Documentos/Inter_KissEspataria/Views/PessoaGarcon/Index.cshtml"
                                               Write(garcon.PessoaId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 48 "/home/luis/Documentos/Inter_KissEspataria/Views/PessoaGarcon/Index.cshtml"
                                               Write(garcon.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 49 "/home/luis/Documentos/Inter_KissEspataria/Views/PessoaGarcon/Index.cshtml"
                                               Write(garcon.CPF);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 50 "/home/luis/Documentos/Inter_KissEspataria/Views/PessoaGarcon/Index.cshtml"
                                               Write(garcon.Telefone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 51 "/home/luis/Documentos/Inter_KissEspataria/Views/PessoaGarcon/Index.cshtml"
                                               Write(garcon.Salario);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 52 "/home/luis/Documentos/Inter_KissEspataria/Views/PessoaGarcon/Index.cshtml"
                                                Write((double)garcon.Comissao);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 53 "/home/luis/Documentos/Inter_KissEspataria/Views/PessoaGarcon/Index.cshtml"
                                               Write(garcon.RegimeTrab);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 54 "/home/luis/Documentos/Inter_KissEspataria/Views/PessoaGarcon/Index.cshtml"
                                               Write(garcon.Ativo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>\r\n                                                    <a class=\"btn btn-sm btn-danger\"");
            BeginWriteAttribute("href", " href=\"", 2540, "\"", 2584, 2);
            WriteAttributeValue("", 2547, "/pessoagarcon/delete/", 2547, 21, true);
#nullable restore
#line 56 "/home/luis/Documentos/Inter_KissEspataria/Views/PessoaGarcon/Index.cshtml"
WriteAttributeValue("", 2568, garcon.PessoaId, 2568, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Apagar</a>\r\n                                                    <a class=\"btn btn-sm btn-warning\"");
            BeginWriteAttribute("href", "\r\n                                    href=\"", 2683, "\"", 2764, 2);
            WriteAttributeValue("", 2727, "/pessoagarcon/update/", 2727, 21, true);
#nullable restore
#line 58 "/home/luis/Documentos/Inter_KissEspataria/Views/PessoaGarcon/Index.cshtml"
WriteAttributeValue("", 2748, garcon.PessoaId, 2748, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Editar</a>\r\n                                                </td>\r\n                                            </tr>\r\n                                        </tbody>\r\n");
#nullable restore
#line 62 "/home/luis/Documentos/Inter_KissEspataria/Views/PessoaGarcon/Index.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <a class=""btn btn-primary"" href=""/pessoagarcon/create"">Adicionar</a>
");
#nullable restore
#line 70 "/home/luis/Documentos/Inter_KissEspataria/Views/PessoaGarcon/Index.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""container-xl px-4 mt-4"">
    <div class=""card mb-4"">
        <div class=""card-header"">Garçons</div>
        <div class=""card-body p-0"">
            <div class=""table-responsive table-billing-history"">
                <table class=""table mb-0"">
                    <thead>
                        <tr>
                            <th class=""border-gray-200"" scope=""col"">Id</th>
                            <th class=""border-gray-200"" scope=""col"">Nome</th>
                            <th class=""border-gray-200"" scope=""col"">CPF</th>
                            <th class=""border-gray-200"" scope=""col"">Telefone</th>
                            <th class=""border-gray-200"" scope=""col"">Salario</th>
                            <th class=""border-gray-200"" scope=""col"">Comissão</th>
                            <th class=""border-gray-200"" scope=""col"">Regime Trab.</th>
                            <th class=""border-gray-200"" scope=""col"">Ativo</th>
                        </tr>
       ");
            WriteLiteral("             </thead>\r\n                    <tbody>\r\n");
#nullable restore
#line 92 "/home/luis/Documentos/Inter_KissEspataria/Views/PessoaGarcon/Index.cshtml"
                         foreach (var garcon in Model)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tbody>\r\n                                            <tr>\r\n                                                <td>");
#nullable restore
#line 96 "/home/luis/Documentos/Inter_KissEspataria/Views/PessoaGarcon/Index.cshtml"
                                               Write(garcon.PessoaId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 97 "/home/luis/Documentos/Inter_KissEspataria/Views/PessoaGarcon/Index.cshtml"
                                               Write(garcon.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 98 "/home/luis/Documentos/Inter_KissEspataria/Views/PessoaGarcon/Index.cshtml"
                                               Write(garcon.CPF);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 99 "/home/luis/Documentos/Inter_KissEspataria/Views/PessoaGarcon/Index.cshtml"
                                               Write(garcon.Telefone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 100 "/home/luis/Documentos/Inter_KissEspataria/Views/PessoaGarcon/Index.cshtml"
                                               Write(garcon.Salario);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 101 "/home/luis/Documentos/Inter_KissEspataria/Views/PessoaGarcon/Index.cshtml"
                                                Write((double)garcon.Comissao);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 102 "/home/luis/Documentos/Inter_KissEspataria/Views/PessoaGarcon/Index.cshtml"
                                               Write(garcon.RegimeTrab);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 103 "/home/luis/Documentos/Inter_KissEspataria/Views/PessoaGarcon/Index.cshtml"
                                               Write(garcon.Ativo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            </tr>\r\n                                        </tbody>\r\n");
#nullable restore
#line 106 "/home/luis/Documentos/Inter_KissEspataria/Views/PessoaGarcon/Index.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </tbody>\r\n                                </table>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 113 "/home/luis/Documentos/Inter_KissEspataria/Views/PessoaGarcon/Index.cshtml"
            }
        }
    }
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Microsoft.AspNetCore.Http.IHttpContextAccessor HttpContextAccessor { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<PessoaGarcon>> Html { get; private set; }
    }
}
#pragma warning restore 1591
