#pragma checksum "E:\Albin\Bosco Soft\Web Application\VehicleServiceManagement\VehicleServiceManagement\Areas\Report\Views\Report\Report.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "22f9975019950ac8365418fc26a23385306d23eb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Report_Views_Report_Report), @"mvc.1.0.view", @"/Areas/Report/Views/Report/Report.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Report/Views/Report/Report.cshtml", typeof(AspNetCore.Areas_Report_Views_Report_Report))]
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
#line 1 "E:\Albin\Bosco Soft\Web Application\VehicleServiceManagement\VehicleServiceManagement\Areas\Report\_ViewImports.cshtml"
using VehicleServiceManagement;

#line default
#line hidden
#line 2 "E:\Albin\Bosco Soft\Web Application\VehicleServiceManagement\VehicleServiceManagement\Areas\Report\_ViewImports.cshtml"
using VehicleServiceManagement.Areas.Report.Models;

#line default
#line hidden
#line 2 "E:\Albin\Bosco Soft\Web Application\VehicleServiceManagement\VehicleServiceManagement\Areas\Report\Views\Report\Report.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#line 3 "E:\Albin\Bosco Soft\Web Application\VehicleServiceManagement\VehicleServiceManagement\Areas\Report\Views\Report\Report.cshtml"
using VehicleSeviceManagement.Framework.Helper;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"22f9975019950ac8365418fc26a23385306d23eb", @"/Areas/Report/Views/Report/Report.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"212452f69614f58f1ee6304e82b6117f32bdbc41", @"/Areas/Report/_ViewImports.cshtml")]
    public class Areas_Report_Views_Report_Report : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<reportCommanModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Images/loader.gif"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("50"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datatables/datatables.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Report", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Report", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Export", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onclick", new global::Microsoft.AspNetCore.Html.HtmlString("ExportData(2,\'Report\');"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Export To Excel"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("color:green"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onclick", new global::Microsoft.AspNetCore.Html.HtmlString("ExportData(1,\'Report\');"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Export To Word"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("color:blue"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_13 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_14 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/datatables/datatables.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(111, 207, true);
            WriteLiteral("<!--Grid Form-->\r\n<style>\r\n    .loader {\r\n        position: fixed;\r\n        left: 50%;\r\n        top: 50%;\r\n        background-color: none;\r\n    }\r\n</style>\r\n<div class=\"\">\r\n    <div class=\"loader\">\r\n        ");
            EndContext();
            BeginContext(318, 44, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "22f9975019950ac8365418fc26a23385306d23eb9467", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(362, 22, true);
            WriteLiteral("\r\n    </div>\r\n</div>\r\n");
            EndContext();
            BeginContext(384, 72, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "22f9975019950ac8365418fc26a23385306d23eb10743", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(456, 1863, true);
            WriteLiteral(@"
<div class=""flex flex-1  flex-col md:flex-row lg:flex-row mx-2 mb-6"">
    <div class=""mb-2 border-solid border-gray-300 rounded border shadow-sm w-full"">
        <div class=""bg-gray-500 px-2 py-3 border-solid border-gray-400 border-b mt-4 text-center"" style=""color:white;font-size:30px"">
            VEHICLE DETAILS REPORT
        </div>
        <br />
        <div class=""container "" id=""ExportHtml"">
            <table class=""table-striped table-bordered dt-responsive nowrap table-hover table-responsive mytable"" style=""width:99.9% ;cursor:not-allowed;"" id=""mysort"">
                <thead class=""bg-grey-dark text-white text-normal"">
                    <tr>
                        <th class=""border w-1/6 px-4 py-2"">CustomerName</th>
                        <th class=""border w-1/6 px-4 py-2"">Email</th>
                        <th class=""border w-1/6 px-4 py-2"">MobileNo</th>
                        <th class=""border w-1/6 px-4 py-2"">Address</th>
                        <th class=""border w-1/6 px-4 ");
            WriteLiteral(@"py-2"">VehicleNo</th>
                        <th class=""border w-1/6 px-4 py-2"">VehicleBrand</th>
                        <th class=""border w-1/6 px-4 py-2"">VehicleModel</th>
                        <th class=""border w-1/6 px-4 py-2"">VehicleColor</th>
                        <th class=""border w-1/6 px-4 py-2"">VehicleKmsRan</th>
                        <th class=""border w-1/6 px-4 py-2"">ExpectedDelivery</th>
                        <th class=""border w-1/6 px-4 py-2"">TotalPrice</th>
                    </tr>
                </thead>
                <tbody>
                    <div class=""row noprint text-right"">
                        <div class=""col-md-6 float-right noprint"">
                            <a onclick="" printScrollingDiv()"" title=""Print""><i class=""fa fa-print""></i>Print</a>
                            ");
            EndContext();
            BeginContext(2319, 184, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "22f9975019950ac8365418fc26a23385306d23eb13945", async() => {
                BeginContext(2462, 37, true);
                WriteLiteral("<i class=\"fa fa-file-excel\"></i>Excel");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2503, 30, true);
            WriteLiteral("\r\n                            ");
            EndContext();
            BeginContext(2533, 180, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "22f9975019950ac8365418fc26a23385306d23eb16037", async() => {
                BeginContext(2674, 35, true);
                WriteLiteral("<i class=\"fa fa-file-word\"></i>Word");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_12);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2713, 62, true);
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n");
            EndContext();
#line 50 "E:\Albin\Bosco Soft\Web Application\VehicleServiceManagement\VehicleServiceManagement\Areas\Report\Views\Report\Report.cshtml"
                     foreach (report report in Model.reportList)
                    {

#line default
#line hidden
            BeginContext(2864, 62, true);
            WriteLiteral("                        <tr>\r\n                            <td>");
            EndContext();
            BeginContext(2927, 19, false);
#line 53 "E:\Albin\Bosco Soft\Web Application\VehicleServiceManagement\VehicleServiceManagement\Areas\Report\Views\Report\Report.cshtml"
                           Write(report.CustomerName);

#line default
#line hidden
            EndContext();
            BeginContext(2946, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(2986, 12, false);
#line 54 "E:\Albin\Bosco Soft\Web Application\VehicleServiceManagement\VehicleServiceManagement\Areas\Report\Views\Report\Report.cshtml"
                           Write(report.Email);

#line default
#line hidden
            EndContext();
            BeginContext(2998, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(3038, 15, false);
#line 55 "E:\Albin\Bosco Soft\Web Application\VehicleServiceManagement\VehicleServiceManagement\Areas\Report\Views\Report\Report.cshtml"
                           Write(report.MobileNo);

#line default
#line hidden
            EndContext();
            BeginContext(3053, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(3093, 14, false);
#line 56 "E:\Albin\Bosco Soft\Web Application\VehicleServiceManagement\VehicleServiceManagement\Areas\Report\Views\Report\Report.cshtml"
                           Write(report.Address);

#line default
#line hidden
            EndContext();
            BeginContext(3107, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(3147, 16, false);
#line 57 "E:\Albin\Bosco Soft\Web Application\VehicleServiceManagement\VehicleServiceManagement\Areas\Report\Views\Report\Report.cshtml"
                           Write(report.VehicleNo);

#line default
#line hidden
            EndContext();
            BeginContext(3163, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(3203, 19, false);
#line 58 "E:\Albin\Bosco Soft\Web Application\VehicleServiceManagement\VehicleServiceManagement\Areas\Report\Views\Report\Report.cshtml"
                           Write(report.VehicleBrand);

#line default
#line hidden
            EndContext();
            BeginContext(3222, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(3262, 19, false);
#line 59 "E:\Albin\Bosco Soft\Web Application\VehicleServiceManagement\VehicleServiceManagement\Areas\Report\Views\Report\Report.cshtml"
                           Write(report.VehicleModel);

#line default
#line hidden
            EndContext();
            BeginContext(3281, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(3321, 19, false);
#line 60 "E:\Albin\Bosco Soft\Web Application\VehicleServiceManagement\VehicleServiceManagement\Areas\Report\Views\Report\Report.cshtml"
                           Write(report.VehicleColor);

#line default
#line hidden
            EndContext();
            BeginContext(3340, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(3380, 20, false);
#line 61 "E:\Albin\Bosco Soft\Web Application\VehicleServiceManagement\VehicleServiceManagement\Areas\Report\Views\Report\Report.cshtml"
                           Write(report.VehicleKmsRan);

#line default
#line hidden
            EndContext();
            BeginContext(3400, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(3440, 63, false);
#line 62 "E:\Albin\Bosco Soft\Web Application\VehicleServiceManagement\VehicleServiceManagement\Areas\Report\Views\Report\Report.cshtml"
                           Write(Convert.ToDateTime(report.ExpectedDelivery).ToShortDateString());

#line default
#line hidden
            EndContext();
            BeginContext(3503, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(3543, 34, false);
#line 63 "E:\Albin\Bosco Soft\Web Application\VehicleServiceManagement\VehicleServiceManagement\Areas\Report\Views\Report\Report.cshtml"
                           Write(Convert.ToInt32(report.TotalPrice));

#line default
#line hidden
            EndContext();
            BeginContext(3577, 38, true);
            WriteLiteral("</td>\r\n                        </tr>\r\n");
            EndContext();
#line 65 "E:\Albin\Bosco Soft\Web Application\VehicleServiceManagement\VehicleServiceManagement\Areas\Report\Views\Report\Report.cshtml"
                    }

#line default
#line hidden
            BeginContext(3638, 161, true);
            WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n</div>\r\n<div id=\"export-content\">\r\n</div>\r\n<!--/Grid Form-->\r\n<!-- TO use Jquery-->\r\n");
            EndContext();
            BeginContext(3799, 42, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "22f9975019950ac8365418fc26a23385306d23eb23923", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_13);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3841, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(3843, 62, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "22f9975019950ac8365418fc26a23385306d23eb25104", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_14);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3905, 5019, true);
            WriteLiteral(@"
<script>
  
     //This is for sorting by plugin
    $(document).ready(function () {
        $('#mysort').DataTable();
    });
    //To use loader
    $(window).load(function () {
        $("".loader"").fadeOut(""slow"");
    });
    //This is for exporting excel,wordm, print
    function printScrollingDiv(divName, paging) {
        if (!paging) {
            paging = 0;
        }
        if (paging != 0) {
            var table = $('.table').DataTable();
            var pagelength = table.page.len();
            table.page.len(-1).draw();
        }
        $(""#export-content"").html($(""#ExportHtml"").html());
        $(""#export-content"").find("".dataTables_filter"").remove();
        $(""#export-content"").find("".dataTables_info"").remove();
        $(""#export-content"").find("".dataTables_length"").remove();
        $(""#export-content"").find("".dataTables_paginate"").remove();
        $(""#export-content"").find("".noprint"").remove();
        var header = ""<html> <head><style> table { font-size:8pt");
            WriteLiteral(@" !important; width: auto  !important; overflow: hidden !important;} "" +
            "" body{  font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000; font-style: normal; }"" +
            "" p{ font-size: 8pt; } label{ font-size: 8pt; }"" +
            "" .pagecaption 	{ font-weight: bold; font-size: 16pt; }"" +
            "" h4	{ margin-bottom:2px  !important;font-size: 12pt;} h5,h6{ margin:5px 0 5px  !important;  font-size: 10pt; font-weight:bold !important;} h6	{ font-weight: normal; font-size: 10pt   !important; }"" +
            "" table			{ border-top: gray 1px solid; border-left: gray 1px solid; font-size:8pt;border-collapse: collapse;width:auto !important;min-width:50% !importnat}"" +
            ""  table td		{ border-right: gray 1px solid; border-bottom: gray 1px solid; padding: 3px;border-collapse: collapse;}"" +
            "" table th		{ border-right: gray 1px solid; border-bottom: gray 1px solid; padding: 3px; font: bold; background-color: #CCCCCC; text-align: left;border-collapse: collap");
            WriteLiteral(@"se;margin:0 !important; }"" +
            ""a{text-decoration: none;pointer-events:none;color:#000;}.dataTables_empty{text-align:center}"" +
            ""h5 {font-weight: 700 !important;font-size: 9pt!important;}"" +
            ""h6 {font-weight: normal!important;font-size: 9pt!important;}"" +
            ""</style>  <title>Vehicle Service Management</title></head><body>"";
        var footer = ""</body></html>"";
        var export_data = header + $(""#export-content"").html() + footer;
        $(""#export-content"").html('');
        var w = window.open();
        var html = export_data;
        $(w.document.body).html(html);
        if (paging != 0) {
            table.page.len(pagelength).draw();
        }
    }
    function ExportData(export_type, file_name, paging = 0) {
        if (paging != 0) {
            var table = $('.mytable').DataTable();
            var pagelength = table.page.len();
            table.page.len(-1).draw();
        }
        $(""#export-content"").html($(""#ExportHtml"").htm");
            WriteLiteral(@"l());
        $(""#export-content"").find("".noprint"").remove();
        $(""#export-content"").find("".dataTables_filter"").remove();
        $(""#export-content"").find("".dataTables_info"").remove();
        $(""#export-content"").find("".dataTables_length"").remove();
        $(""#export-content"").find("".dataTables_paginate"").remove();
        var header = ""<html> <head><style> table { font-size:9pt; } "" +
            "" body{  font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000; font-style: normal; }"" +
            "" p{ font-size: 8pt; } label{ font-size: 8pt; }"" +
            "" .pagecaption 	{ font-weight: bold; font-size: 16pt; }"" +

            ""  h4	{ margin-bottom:2px  !important;font-size: 12pt;} h5,h6{ margin:5px 0 5px  !important;  font-size: 10pt;} h6	{ font-weight: bold; font-size: 10pt   !important; }"" +
            "" table			{ border-top: gray 1px solid; border-left: gray 1px solid; font-size:8pt;border-collapse:collapse}"" + "".table_positionset{ margin-top:10px !important;}"" +
    ");
            WriteLiteral(@"        ""  table td		{ border-right: gray 1px solid; border-bottom: gray 1px solid; padding: 3px;}"" +
            "" table th		{ border-right: gray 1px solid; border-bottom: gray 1px solid; padding: 3px; font: bold; background-color: #CCCCCC; text-align: left; }"" +
            "".dataTables_scrollBody table thead {display:none !important}"" +
            ""a{text-decoration: none;pointer-events:none;color:#000;}.dataTables_empty{text-align:center}"" +

            ""h5 {font-weight: normal!important;font-size: 9pt!important;}"" +
            ""h6 {font-weight: normal!important;font-size: 9pt!important;}"" +
            ""</style>  <title>Option C</title></head><body>"";
        var footer = ""</body></html>"";
        var export_data = header + $(""#export-content"").html() + footer;
        $(""#export-content"").html('');

        // This will be called when the action clicked
        $.ajax({
            url:'");
            EndContext();
            BeginContext(8925, 39, false);
#line 158 "E:\Albin\Bosco Soft\Web Application\VehicleServiceManagement\VehicleServiceManagement\Areas\Report\Views\Report\Report.cshtml"
            Write(Url.Action("SetExportOptions","Report"));

#line default
#line hidden
            EndContext();
            BeginContext(8964, 411, true);
            WriteLiteral(@"',
            data: { exportHtml: export_data, exportType: export_type, fileName: file_name },
            cache: false,
            async: false,
            type: ""POST"",
            success: function (data) {
            },
            error: function (reponse) {

            }
        });

        if (paging != 0) {
            table.page.len(pagelength).draw();
        }
    }
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<reportCommanModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
