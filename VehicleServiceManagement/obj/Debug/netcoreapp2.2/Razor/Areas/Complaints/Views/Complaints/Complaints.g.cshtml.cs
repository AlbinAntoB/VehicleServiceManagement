#pragma checksum "E:\Albin\Bosco Soft\Web Application\VehicleServiceManagement\VehicleServiceManagement\Areas\Complaints\Views\Complaints\Complaints.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3aff807dbcc13599f005b9d45f1a55e5b239960b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Complaints_Views_Complaints_Complaints), @"mvc.1.0.view", @"/Areas/Complaints/Views/Complaints/Complaints.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Complaints/Views/Complaints/Complaints.cshtml", typeof(AspNetCore.Areas_Complaints_Views_Complaints_Complaints))]
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
#line 1 "E:\Albin\Bosco Soft\Web Application\VehicleServiceManagement\VehicleServiceManagement\Areas\Complaints\_ViewImports.cshtml"
using VehicleServiceManagement;

#line default
#line hidden
#line 2 "E:\Albin\Bosco Soft\Web Application\VehicleServiceManagement\VehicleServiceManagement\Areas\Complaints\_ViewImports.cshtml"
using VehicleServiceManagement.Areas.Complaints.Models;

#line default
#line hidden
#line 2 "E:\Albin\Bosco Soft\Web Application\VehicleServiceManagement\VehicleServiceManagement\Areas\Complaints\Views\Complaints\Complaints.cshtml"
using VehicleSeviceManagement.Framework.Helper;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3aff807dbcc13599f005b9d45f1a55e5b239960b", @"/Areas/Complaints/Views/Complaints/Complaints.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fb4731f8afe53403c0c58bcf79c54aa53bb0391c", @"/Areas/Complaints/_ViewImports.cshtml")]
    public class Areas_Complaints_Views_Complaints_Complaints : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ComplaintsCommanModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datatables/datatables.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("flex-auto"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("bg-300 cursor-pointer rounded p-1 mx-1 text-white"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Complaints", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Complaints", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditComplaint", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datatables/datatables.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(80, 18, true);
            WriteLiteral("<!-- Main CSS-->\r\n");
            EndContext();
            BeginContext(98, 90, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3aff807dbcc13599f005b9d45f1a55e5b239960b7070", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(188, 493, true);
            WriteLiteral(@"
<div class=""flex flex-1  flex-col md:flex-row lg:flex-row mx-2 mb-5"">
    <div class=""mb-2 border-solid border-gray-300 rounded border shadow-sm w-full"">
        <div class=""bg-gray-500 px-2 py-3 border-solid border-gray-400 border-b mt-4 text-center"" style=""color:white;font-size:30px"">
            COMPLAINT DETAILS
        </div>
        <div class=""text-right mt-2"">
            <input class=""bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded mb-2"" type=""button""");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 681, "\"", 770, 1);
#line 11 "E:\Albin\Bosco Soft\Web Application\VehicleServiceManagement\VehicleServiceManagement\Areas\Complaints\Views\Complaints\Complaints.cshtml"
WriteAttributeValue("", 691, "window.location.href='" + @Url.Action("Complaintsform", "Complaints") + "'", 691, 79, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(771, 124, true);
            WriteLiteral(" value=\"Add New Complaint\" style=\"height:40px; width:300px;\" />\r\n        </div>\r\n        <div class=\"table-responsive-md\">\r\n");
            EndContext();
#line 14 "E:\Albin\Bosco Soft\Web Application\VehicleServiceManagement\VehicleServiceManagement\Areas\Complaints\Views\Complaints\Complaints.cshtml"
             if (Model.customerComplaintsList != null)
            {

#line default
#line hidden
            BeginContext(966, 671, true);
            WriteLiteral(@"                <table class=""table-striped table-bordered dt-responsive nowrap table-hover table-responsive-lg"" id=""mysort"" style=""cursor:not-allowed;"">
                    <thead class=""bg-grey-dark text-white text-normal"">
                        <tr>
                            <th class=""border w-1/6 px-4 py-2"">Action</th>
                            <th class=""border w-1/6 px-4 py-2"">Complaints</th>
                            <th class=""border w-1/6 px-4 py-2 text-right"">Price</th>
                            <th class=""border w-1/6 px-4 py-2"">VehicleType</th>
                        </tr>
                    </thead>
                    <tbody>
");
            EndContext();
#line 26 "E:\Albin\Bosco Soft\Web Application\VehicleServiceManagement\VehicleServiceManagement\Areas\Complaints\Views\Complaints\Complaints.cshtml"
                         foreach (CustomerComplaints complaints in Model.customerComplaintsList)
                        {

#line default
#line hidden
            BeginContext(1762, 133, true);
            WriteLiteral("                            <tr>\r\n                                <td class=\"border px-4 py-2\">\r\n                                    ");
            EndContext();
            BeginContext(1895, 321, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3aff807dbcc13599f005b9d45f1a55e5b239960b11157", async() => {
                BeginContext(2081, 131, true);
                WriteLiteral("\r\n                                        <i class=\"fas fa-edit\" style=\"color:Highlight\"></i>\r\n                                    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-ComplaintId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 30 "E:\Albin\Bosco Soft\Web Application\VehicleServiceManagement\VehicleServiceManagement\Areas\Complaints\Views\Complaints\Complaints.cshtml"
                                                                                                            WriteLiteral(complaints.ComplaintId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["ComplaintId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-ComplaintId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["ComplaintId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2216, 100, true);
            WriteLiteral("\r\n                                    <a class=\"bg-300 cursor-pointer rounded p-1 mx-1 text-red-500\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 2316, "\"", 2367, 3);
            WriteAttributeValue("", 2326, "Deletecomplaints(", 2326, 17, true);
#line 33 "E:\Albin\Bosco Soft\Web Application\VehicleServiceManagement\VehicleServiceManagement\Areas\Complaints\Views\Complaints\Complaints.cshtml"
WriteAttributeValue("", 2343, complaints.ComplaintId, 2343, 23, false);

#line default
#line hidden
            WriteAttributeValue("", 2366, ")", 2366, 1, true);
            EndWriteAttribute();
            BeginContext(2368, 214, true);
            WriteLiteral(">\r\n                                        <i class=\"fas fa-trash\" style=\"color:Highlight\"></i>\r\n                                    </a>\r\n                                </td>\r\n                                <td>");
            EndContext();
            BeginContext(2583, 21, false);
#line 37 "E:\Albin\Bosco Soft\Web Application\VehicleServiceManagement\VehicleServiceManagement\Areas\Complaints\Views\Complaints\Complaints.cshtml"
                               Write(complaints.Complaints);

#line default
#line hidden
            EndContext();
            BeginContext(2604, 76, true);
            WriteLiteral("</td>\r\n                                <td class=\"text-right\"><span>₹</span>");
            EndContext();
            BeginContext(2681, 33, false);
#line 38 "E:\Albin\Bosco Soft\Web Application\VehicleServiceManagement\VehicleServiceManagement\Areas\Complaints\Views\Complaints\Complaints.cshtml"
                                                                Write(Convert.ToInt32(complaints.Price));

#line default
#line hidden
            EndContext();
            BeginContext(2714, 45, true);
            WriteLiteral("</td>\r\n                                <td>\r\n");
            EndContext();
#line 40 "E:\Albin\Bosco Soft\Web Application\VehicleServiceManagement\VehicleServiceManagement\Areas\Complaints\Views\Complaints\Complaints.cshtml"
                                     for (int j = 0; j < Model.vehicleTypesList.Count; j++)
                                    {
                                        String Count = @complaints.VehicleTypeId.ToString();
                                        if (Count.Contains(Model.vehicleTypesList[j].VehicleTypeId.ToString()))
                                        {
                                            

#line default
#line hidden
            BeginContext(3186, 37, false);
#line 45 "E:\Albin\Bosco Soft\Web Application\VehicleServiceManagement\VehicleServiceManagement\Areas\Complaints\Views\Complaints\Complaints.cshtml"
                                       Write(Model.vehicleTypesList[j].VehicleType);

#line default
#line hidden
            EndContext();
#line 45 "E:\Albin\Bosco Soft\Web Application\VehicleServiceManagement\VehicleServiceManagement\Areas\Complaints\Views\Complaints\Complaints.cshtml"
                                                                                  

                                        }

                                    }

#line default
#line hidden
            BeginContext(3311, 74, true);
            WriteLiteral("                                </td>\r\n                            </tr>\r\n");
            EndContext();
#line 52 "E:\Albin\Bosco Soft\Web Application\VehicleServiceManagement\VehicleServiceManagement\Areas\Complaints\Views\Complaints\Complaints.cshtml"
                        }

#line default
#line hidden
            BeginContext(3412, 56, true);
            WriteLiteral("                    </tbody>\r\n                </table>\r\n");
            EndContext();
#line 55 "E:\Albin\Bosco Soft\Web Application\VehicleServiceManagement\VehicleServiceManagement\Areas\Complaints\Views\Complaints\Complaints.cshtml"
            }
            else
            {

#line default
#line hidden
            BeginContext(3516, 165, true);
            WriteLiteral("                <br />\r\n                <div class=\"text-center\">\r\n                    <h4 style=\"color:lightseagreen\">No record found</h4>\r\n                </div>\r\n");
            EndContext();
#line 62 "E:\Albin\Bosco Soft\Web Application\VehicleServiceManagement\VehicleServiceManagement\Areas\Complaints\Views\Complaints\Complaints.cshtml"
            }

#line default
#line hidden
            BeginContext(3696, 59, true);
            WriteLiteral("        </div>\r\n    </div>\r\n</div>\r\n<!-- TO use Jquery-->\r\n");
            EndContext();
            BeginContext(3755, 42, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3aff807dbcc13599f005b9d45f1a55e5b239960b18954", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3797, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(3799, 62, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3aff807dbcc13599f005b9d45f1a55e5b239960b20134", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3861, 354, true);
            WriteLiteral(@"

<script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js""></script>
<script src=""https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js""></script>
<script>
    //To Deletecomplaints
    function Deletecomplaints(ComplaintId) {
        var x = confirm(""Are you sure do you want to delete?"");
        var url = '");
            EndContext();
            BeginContext(4216, 43, false);
#line 76 "E:\Albin\Bosco Soft\Web Application\VehicleServiceManagement\VehicleServiceManagement\Areas\Complaints\Views\Complaints\Complaints.cshtml"
              Write(Url.Action("DeleteComplaint", "Complaints"));

#line default
#line hidden
            EndContext();
            BeginContext(4259, 358, true);
            WriteLiteral(@"' + '?ComplaintId=' + ComplaintId;
        if (x)
            //""/Vehicle/DeleteComplaint?ComplaintId="" + ComplaintId
            window.location.href = url;
        else
            return false;
    }
</script>
<script>
    //This is for sorting by plugin
    $(document).ready(function () {
        $('#mysort').DataTable();
    });
</script>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ComplaintsCommanModel> Html { get; private set; }
    }
}
#pragma warning restore 1591