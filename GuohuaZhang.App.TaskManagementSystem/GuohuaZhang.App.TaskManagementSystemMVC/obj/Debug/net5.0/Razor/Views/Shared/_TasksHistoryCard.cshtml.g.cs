#pragma checksum "C:\Alvin\GuohuaZhangTasK\GuohuaZhang.App.TaskManagementSystem\GuohuaZhang.App.TaskManagementSystemMVC\Views\Shared\_TasksHistoryCard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6dd1d6992a59810c59ee36ccaa6447e3e611e0f5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__TasksHistoryCard), @"mvc.1.0.view", @"/Views/Shared/_TasksHistoryCard.cshtml")]
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
#line 1 "C:\Alvin\GuohuaZhangTasK\GuohuaZhang.App.TaskManagementSystem\GuohuaZhang.App.TaskManagementSystemMVC\Views\_ViewImports.cshtml"
using GuohuaZhang.App.TaskManagementSystemMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Alvin\GuohuaZhangTasK\GuohuaZhang.App.TaskManagementSystem\GuohuaZhang.App.TaskManagementSystemMVC\Views\_ViewImports.cshtml"
using GuohuaZhang.App.TaskManagementSystemMVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6dd1d6992a59810c59ee36ccaa6447e3e611e0f5", @"/Views/Shared/_TasksHistoryCard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a1212f001f1fb796dd7e98634a7758166a006bad", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__TasksHistoryCard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ApplicationCore.Models.TasksHistoryCardResponseModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Movies", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n<div class=\"card mb-2 shadow bg-light\">\r\n\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6dd1d6992a59810c59ee36ccaa6447e3e611e0f54038", async() => {
                WriteLiteral("\r\n        <p>UserId       : ");
#nullable restore
#line 6 "C:\Alvin\GuohuaZhangTasK\GuohuaZhang.App.TaskManagementSystem\GuohuaZhang.App.TaskManagementSystemMVC\Views\Shared\_TasksHistoryCard.cshtml"
                     Write(Model.UserId);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n        <p>Title        : ");
#nullable restore
#line 7 "C:\Alvin\GuohuaZhangTasK\GuohuaZhang.App.TaskManagementSystem\GuohuaZhang.App.TaskManagementSystemMVC\Views\Shared\_TasksHistoryCard.cshtml"
                     Write(Model.Title);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n        <p>Description  : ");
#nullable restore
#line 8 "C:\Alvin\GuohuaZhangTasK\GuohuaZhang.App.TaskManagementSystem\GuohuaZhang.App.TaskManagementSystemMVC\Views\Shared\_TasksHistoryCard.cshtml"
                     Write(Model.Description);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n        <p>DueDate      : ");
#nullable restore
#line 9 "C:\Alvin\GuohuaZhangTasK\GuohuaZhang.App.TaskManagementSystem\GuohuaZhang.App.TaskManagementSystemMVC\Views\Shared\_TasksHistoryCard.cshtml"
                     Write(Model.DueDate);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n        <p>Completed    : ");
#nullable restore
#line 10 "C:\Alvin\GuohuaZhangTasK\GuohuaZhang.App.TaskManagementSystem\GuohuaZhang.App.TaskManagementSystemMVC\Views\Shared\_TasksHistoryCard.cshtml"
                     Write(Model.Completed);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n        <p>Remarks      : ");
#nullable restore
#line 11 "C:\Alvin\GuohuaZhangTasK\GuohuaZhang.App.TaskManagementSystem\GuohuaZhang.App.TaskManagementSystemMVC\Views\Shared\_TasksHistoryCard.cshtml"
                     Write(Model.Remarks);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 5 "C:\Alvin\GuohuaZhangTasK\GuohuaZhang.App.TaskManagementSystem\GuohuaZhang.App.TaskManagementSystemMVC\Views\Shared\_TasksHistoryCard.cshtml"
                                                      WriteLiteral(Model.TaskId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ApplicationCore.Models.TasksHistoryCardResponseModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
