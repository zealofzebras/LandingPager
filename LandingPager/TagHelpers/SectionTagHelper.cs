using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Threading.Tasks;

namespace LandingPager.TagHelpers
{
    public class SectionTagHelper : TagHelper
    {
        /*
        protected HttpRequest Request => ViewContext.HttpContext.Request;
        protected HttpResponse Response => ViewContext.HttpContext.Response;
        */

        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var content = await output.GetChildContentAsync();
            ViewContext.HttpContext.Items["_script_" + Guid.NewGuid()] = content;
            output.SuppressOutput();
        }
    }
}
