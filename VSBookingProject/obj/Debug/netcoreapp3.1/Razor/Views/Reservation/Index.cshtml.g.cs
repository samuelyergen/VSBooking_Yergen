#pragma checksum "C:\Users\Maintenant Prêt\Desktop\rrreendu\VSBookingProject\VSBookingProject\Views\Reservation\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "299d7f42ab97d3a5034c45e2dcde0277ca49b6a3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Reservation_Index), @"mvc.1.0.view", @"/Views/Reservation/Index.cshtml")]
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
#line 1 "C:\Users\Maintenant Prêt\Desktop\rrreendu\VSBookingProject\VSBookingProject\Views\_ViewImports.cshtml"
using VSBookingProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Maintenant Prêt\Desktop\rrreendu\VSBookingProject\VSBookingProject\Views\_ViewImports.cshtml"
using VSBookingProject.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"299d7f42ab97d3a5034c45e2dcde0277ca49b6a3", @"/Views/Reservation/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e4a93ad29ca1122b19f9cc221e765b96a448ccc5", @"/Views/_ViewImports.cshtml")]
    public class Views_Reservation_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<DTO.Reservation>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Maintenant Prêt\Desktop\rrreendu\VSBookingProject\VSBookingProject\Views\Reservation\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>My reservations</h1>\r\n\r\n<pre>\r\n\r\n</pre>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "C:\Users\Maintenant Prêt\Desktop\rrreendu\VSBookingProject\VSBookingProject\Views\Reservation\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.IdReservation));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "C:\Users\Maintenant Prêt\Desktop\rrreendu\VSBookingProject\VSBookingProject\Views\Reservation\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Firstname));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "C:\Users\Maintenant Prêt\Desktop\rrreendu\VSBookingProject\VSBookingProject\Views\Reservation\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Lastname));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 28 "C:\Users\Maintenant Prêt\Desktop\rrreendu\VSBookingProject\VSBookingProject\Views\Reservation\Index.cshtml"
         if (Model != null)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\Users\Maintenant Prêt\Desktop\rrreendu\VSBookingProject\VSBookingProject\Views\Reservation\Index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 34 "C:\Users\Maintenant Prêt\Desktop\rrreendu\VSBookingProject\VSBookingProject\Views\Reservation\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.IdReservation));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 37 "C:\Users\Maintenant Prêt\Desktop\rrreendu\VSBookingProject\VSBookingProject\Views\Reservation\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Firstname));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 40 "C:\Users\Maintenant Prêt\Desktop\rrreendu\VSBookingProject\VSBookingProject\Views\Reservation\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Lastname));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>                      \r\n                        ");
#nullable restore
#line 43 "C:\Users\Maintenant Prêt\Desktop\rrreendu\VSBookingProject\VSBookingProject\Views\Reservation\Index.cshtml"
                   Write(Html.ActionLink("Details", "Index", "Booking", new { id = item.IdReservation }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                        ");
#nullable restore
#line 44 "C:\Users\Maintenant Prêt\Desktop\rrreendu\VSBookingProject\VSBookingProject\Views\Reservation\Index.cshtml"
                   Write(Html.ActionLink("Cancel reservation", "Delete", new { id = item.IdReservation }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 47 "C:\Users\Maintenant Prêt\Desktop\rrreendu\VSBookingProject\VSBookingProject\Views\Reservation\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 47 "C:\Users\Maintenant Prêt\Desktop\rrreendu\VSBookingProject\VSBookingProject\Views\Reservation\Index.cshtml"
             
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<DTO.Reservation>> Html { get; private set; }
    }
}
#pragma warning restore 1591