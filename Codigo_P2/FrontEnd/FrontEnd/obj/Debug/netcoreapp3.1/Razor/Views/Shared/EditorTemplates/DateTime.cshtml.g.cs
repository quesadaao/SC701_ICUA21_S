#pragma checksum "C:\Repo\quesadaao\SC701_ICUA21_S\Codigo_P2\FrontEnd\FrontEnd\Views\Shared\EditorTemplates\DateTime.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fb69fe62cc1f30162971ef7d22a232451446ad1e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_EditorTemplates_DateTime), @"mvc.1.0.view", @"/Views/Shared/EditorTemplates/DateTime.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fb69fe62cc1f30162971ef7d22a232451446ad1e", @"/Views/Shared/EditorTemplates/DateTime.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3ea719869d0121793e2abdd0e78c4bddb249e5ed", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_EditorTemplates_DateTime : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DateTime>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<input type=\"date\"");
            BeginWriteAttribute("value", " value=\"", 37, "\"", 74, 1);
#nullable restore
#line 3 "C:\Repo\quesadaao\SC701_ICUA21_S\Codigo_P2\FrontEnd\FrontEnd\Views\Shared\EditorTemplates\DateTime.cshtml"
WriteAttributeValue("", 45, Model.ToString("yyyy-MM-DD"), 45, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("id", "\r\n       id=\"", 75, "\"", 135, 1);
#nullable restore
#line 4 "C:\Repo\quesadaao\SC701_ICUA21_S\Codigo_P2\FrontEnd\FrontEnd\Views\Shared\EditorTemplates\DateTime.cshtml"
WriteAttributeValue("", 88, ViewData.TemplateInfo.GetFullHtmlFieldName(""), 88, 47, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("name", "\r\n       name=\"", 136, "\"", 198, 1);
#nullable restore
#line 5 "C:\Repo\quesadaao\SC701_ICUA21_S\Codigo_P2\FrontEnd\FrontEnd\Views\Shared\EditorTemplates\DateTime.cshtml"
WriteAttributeValue("", 151, ViewData.TemplateInfo.GetFullHtmlFieldName(""), 151, 47, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DateTime> Html { get; private set; }
    }
}
#pragma warning restore 1591