#pragma checksum "C:\Users\nguye\source\repos\Thanh_An_Group\Thanh_An_Group\Areas\Admin\Views\Article\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3a6f5bdeb5d0b466d1851153e04962fa44e13341"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Article_Detail), @"mvc.1.0.view", @"/Areas/Admin/Views/Article/Detail.cshtml")]
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
#line 1 "C:\Users\nguye\source\repos\Thanh_An_Group\Thanh_An_Group\Areas\Admin\Views\_ViewImports.cshtml"
using Thanh_An_Group;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3a6f5bdeb5d0b466d1851153e04962fa44e13341", @"/Areas/Admin/Views/Article/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2cb6ba8f82a9608336375531cb39a451ac1bb1fe", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Article_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ThanhAn_Group.DAL.Models.Baiviet>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\nguye\source\repos\Thanh_An_Group\Thanh_An_Group\Areas\Admin\Views\Article\Detail.cshtml"
  
    ViewData["Title"] = "Detail";
    Layout = "~/Areas/Admin/Views/Shared/Layout_Admin.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Detail</h1>\r\n\r\n<div>\r\n    <h4>Baiviet</h4>\r\n    <hr />\r\n    <dl class=\"row a\" >\r\n       \r\n\r\n     \r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 18 "C:\Users\nguye\source\repos\Thanh_An_Group\Thanh_An_Group\Areas\Admin\Views\Article\Detail.cshtml"
       Write(Html.DisplayNameFor(model => model.Contents));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10 sImages\">\r\n            ");
#nullable restore
#line 21 "C:\Users\nguye\source\repos\Thanh_An_Group\Thanh_An_Group\Areas\Admin\Views\Article\Detail.cshtml"
       Write(Html.Raw(@Model.Contents));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n       }\r\n    </dl>\r\n</div>\r\n<div>\r\n\r\n    <a href=\"/Admin/Article/Index\">Quay Lại</a>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ThanhAn_Group.DAL.Models.Baiviet> Html { get; private set; }
    }
}
#pragma warning restore 1591
