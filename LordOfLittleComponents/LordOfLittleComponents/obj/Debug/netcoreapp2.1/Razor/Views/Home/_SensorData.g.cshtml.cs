#pragma checksum "C:\Users\Ricardo\OneDrive\Documentos\Learning_Arduino_Automation\LordOfLittleComponents\LordOfLittleComponents\Views\Home\_SensorData.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1a7b9ec2ac53ba55bef435280de796e840c1caf6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home__SensorData), @"mvc.1.0.view", @"/Views/Home/_SensorData.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/_SensorData.cshtml", typeof(AspNetCore.Views_Home__SensorData))]
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
#line 1 "C:\Users\Ricardo\OneDrive\Documentos\Learning_Arduino_Automation\LordOfLittleComponents\LordOfLittleComponents\Views\_ViewImports.cshtml"
using LordOfLittleComponents;

#line default
#line hidden
#line 2 "C:\Users\Ricardo\OneDrive\Documentos\Learning_Arduino_Automation\LordOfLittleComponents\LordOfLittleComponents\Views\_ViewImports.cshtml"
using LordOfLittleComponents.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1a7b9ec2ac53ba55bef435280de796e840c1caf6", @"/Views/Home/_SensorData.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"775bbeed51f978366462f28c8c4b2679b5bedc4e", @"/Views/_ViewImports.cshtml")]
    public class Views_Home__SensorData : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LordOfLittleComponents.Models.EnvironmentDataViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(63, 39, true);
            WriteLiteral("\r\n\r\n<div id=\"dataFromSensors\">\r\n    <p>");
            EndContext();
            BeginContext(103, 34, false);
#line 5 "C:\Users\Ricardo\OneDrive\Documentos\Learning_Arduino_Automation\LordOfLittleComponents\LordOfLittleComponents\Views\Home\_SensorData.cshtml"
  Write(Html.DisplayFor(model => model.Id));

#line default
#line hidden
            EndContext();
            BeginContext(137, 13, true);
            WriteLiteral("</p>\r\n    <p>");
            EndContext();
            BeginContext(151, 43, false);
#line 6 "C:\Users\Ricardo\OneDrive\Documentos\Learning_Arduino_Automation\LordOfLittleComponents\LordOfLittleComponents\Views\Home\_SensorData.cshtml"
  Write(Html.DisplayFor(model => model.Temperature));

#line default
#line hidden
            EndContext();
            BeginContext(194, 13, true);
            WriteLiteral("</p>\r\n    <p>");
            EndContext();
            BeginContext(208, 40, false);
#line 7 "C:\Users\Ricardo\OneDrive\Documentos\Learning_Arduino_Automation\LordOfLittleComponents\LordOfLittleComponents\Views\Home\_SensorData.cshtml"
  Write(Html.DisplayFor(model => model.Humidity));

#line default
#line hidden
            EndContext();
            BeginContext(248, 16, true);
            WriteLiteral("</p>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LordOfLittleComponents.Models.EnvironmentDataViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
