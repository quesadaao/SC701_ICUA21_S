#pragma checksum "C:\Repo\quesadaao\SC701_ICUA21_S\Codigo_P2\FrontEnd\FrontEnd\Views\Shared\DisplayTemplates\Persona.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "096b4633ec7b2d4bc1bef6024df8f18e70c51669"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_DisplayTemplates_Persona), @"mvc.1.0.view", @"/Views/Shared/DisplayTemplates/Persona.cshtml")]
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
#line 1 "C:\Repo\quesadaao\SC701_ICUA21_S\Codigo_P2\FrontEnd\FrontEnd\Views\_ViewImports.cshtml"
using FrontEnd;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Repo\quesadaao\SC701_ICUA21_S\Codigo_P2\FrontEnd\FrontEnd\Views\_ViewImports.cshtml"
using FrontEnd.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"096b4633ec7b2d4bc1bef6024df8f18e70c51669", @"/Views/Shared/DisplayTemplates/Persona.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3ea719869d0121793e2abdd0e78c4bddb249e5ed", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_DisplayTemplates_Persona : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FrontEnd.Controllers.PersonaTemp>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"form-group\">\r\n    ");
#nullable restore
#line 4 "C:\Repo\quesadaao\SC701_ICUA21_S\Codigo_P2\FrontEnd\FrontEnd\Views\Shared\DisplayTemplates\Persona.cshtml"
Write(Html.LabelFor(model => model.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral(":\r\n    ");
#nullable restore
#line 5 "C:\Repo\quesadaao\SC701_ICUA21_S\Codigo_P2\FrontEnd\FrontEnd\Views\Shared\DisplayTemplates\Persona.cshtml"
Write(Html.DisplayFor(model => model.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n<div class=\"form-group\">\r\n    ");
#nullable restore
#line 9 "C:\Repo\quesadaao\SC701_ICUA21_S\Codigo_P2\FrontEnd\FrontEnd\Views\Shared\DisplayTemplates\Persona.cshtml"
Write(Html.LabelFor(model => model.Edad));

#line default
#line hidden
#nullable disable
            WriteLiteral(":\r\n    ");
#nullable restore
#line 10 "C:\Repo\quesadaao\SC701_ICUA21_S\Codigo_P2\FrontEnd\FrontEnd\Views\Shared\DisplayTemplates\Persona.cshtml"
Write(Html.DisplayFor(model => model.Edad));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n<div class=\"form-group\">\r\n    ");
#nullable restore
#line 14 "C:\Repo\quesadaao\SC701_ICUA21_S\Codigo_P2\FrontEnd\FrontEnd\Views\Shared\DisplayTemplates\Persona.cshtml"
Write(Html.LabelFor(model => model.Nacimiento));

#line default
#line hidden
#nullable disable
            WriteLiteral(":\r\n    ");
#nullable restore
#line 15 "C:\Repo\quesadaao\SC701_ICUA21_S\Codigo_P2\FrontEnd\FrontEnd\Views\Shared\DisplayTemplates\Persona.cshtml"
Write(Html.DisplayFor(model => model.Nacimiento));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n<div class=\"form-group\">\r\n    ");
#nullable restore
#line 19 "C:\Repo\quesadaao\SC701_ICUA21_S\Codigo_P2\FrontEnd\FrontEnd\Views\Shared\DisplayTemplates\Persona.cshtml"
Write(Html.LabelFor(model => model.Empleado));

#line default
#line hidden
#nullable disable
            WriteLiteral(":\r\n    ");
#nullable restore
#line 20 "C:\Repo\quesadaao\SC701_ICUA21_S\Codigo_P2\FrontEnd\FrontEnd\Views\Shared\DisplayTemplates\Persona.cshtml"
Write(Html.DisplayFor(model => model.Empleado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FrontEnd.Controllers.PersonaTemp> Html { get; private set; }
    }
}
#pragma warning restore 1591
