#pragma checksum "C:\Users\Maintenant Prêt\Desktop\rrreendu\VSBookingProject\VSBookingProject\Views\Hotel\RoomDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "60317c8d7119e47844a8c0cab765de2e8b6365a1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Hotel_RoomDetails), @"mvc.1.0.view", @"/Views/Hotel/RoomDetails.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"60317c8d7119e47844a8c0cab765de2e8b6365a1", @"/Views/Hotel/RoomDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e4a93ad29ca1122b19f9cc221e765b96a448ccc5", @"/Views/_ViewImports.cshtml")]
    public class Views_Hotel_RoomDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<VSBookingProject.Models.RoomViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Maintenant Prêt\Desktop\rrreendu\VSBookingProject\VSBookingProject\Views\Hotel\RoomDetails.cshtml"
  
    ViewData["Title"] = "RoomDetails";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Room Details</h1>\r\n\r\n<table>\r\n");
#nullable restore
#line 10 "C:\Users\Maintenant Prêt\Desktop\rrreendu\VSBookingProject\VSBookingProject\Views\Hotel\RoomDetails.cshtml"
     foreach(var p in Model.Pictures)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                <img");
            BeginWriteAttribute("src", " src=", 229, "", 240, 1);
#nullable restore
#line 14 "C:\Users\Maintenant Prêt\Desktop\rrreendu\VSBookingProject\VSBookingProject\Views\Hotel\RoomDetails.cshtml"
WriteAttributeValue("", 234, p.Url, 234, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"image room\"/>\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 17 "C:\Users\Maintenant Prêt\Desktop\rrreendu\VSBookingProject\VSBookingProject\Views\Hotel\RoomDetails.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\r\n\r\n<ul>\r\n    <li>Number of beds : ");
#nullable restore
#line 21 "C:\Users\Maintenant Prêt\Desktop\rrreendu\VSBookingProject\VSBookingProject\Views\Hotel\RoomDetails.cshtml"
                    Write(Model.Room.Type);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n    <li>Description : ");
#nullable restore
#line 22 "C:\Users\Maintenant Prêt\Desktop\rrreendu\VSBookingProject\VSBookingProject\Views\Hotel\RoomDetails.cshtml"
                 Write(Model.Room.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n    <li>Price : ");
#nullable restore
#line 23 "C:\Users\Maintenant Prêt\Desktop\rrreendu\VSBookingProject\VSBookingProject\Views\Hotel\RoomDetails.cshtml"
           Write(Model.Room.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n    <li>TV ? ");
#nullable restore
#line 24 "C:\Users\Maintenant Prêt\Desktop\rrreendu\VSBookingProject\VSBookingProject\Views\Hotel\RoomDetails.cshtml"
        Write(Model.Room.HasTv);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n    <li>Hair dryer ? ");
#nullable restore
#line 25 "C:\Users\Maintenant Prêt\Desktop\rrreendu\VSBookingProject\VSBookingProject\Views\Hotel\RoomDetails.cshtml"
                Write(Model.Room.HasHairDryer);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>   \r\n</ul>\r\n\r\n<div>\r\n    <h4>RoomViewModel</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
#nullable restore
#line 35 "C:\Users\Maintenant Prêt\Desktop\rrreendu\VSBookingProject\VSBookingProject\Views\Hotel\RoomDetails.cshtml"
Write(Html.ActionLink("reserve", "Create", "ReservationController", new { id = Model.Room.IdRoom }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "60317c8d7119e47844a8c0cab765de2e8b6365a16731", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<VSBookingProject.Models.RoomViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
