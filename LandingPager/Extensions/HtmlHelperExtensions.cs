using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandingPager.Extensions
{
    public static class HtmlHelperExtensions
    {

        public static IHtmlHelper AddBodyClass(this IHtmlHelper htmlHelper, string className)
        {
            htmlHelper.ViewContext.HttpContext.Items["_bodyclass_" + Guid.NewGuid()] = className;
            return null;
        }

        public static string GetBodyClasses(this IHtmlHelper htmlHelper)
        {
            var classlist = "";
            foreach (object key in htmlHelper.ViewContext.HttpContext.Items.Keys)
            {
                if (key.ToString().StartsWith("_bodyclass_"))
                {
                    if (htmlHelper.ViewContext.HttpContext.Items[key] is string className)
                    {
                        classlist += (" " + className);
                    }
                }
            }
            return classlist;
        }


        ///<summary>
        /// Adds a partial view script to the Http context to be rendered in the parent view
        /// </summary>

        public static IHtmlHelper Script(this IHtmlHelper htmlHelper, Func<object, HelperResult> template)
        {
            htmlHelper.ViewContext.HttpContext.Items["_script_" + Guid.NewGuid()] = template;
            return null;
        }

        ///<summary>
        /// Renders any scripts used within the partial views
        /// </summary>

        /// 
        public static IHtmlHelper RenderPartialViewScripts(this IHtmlHelper htmlHelper)
        {
            foreach (object key in htmlHelper.ViewContext.HttpContext.Items.Keys)
            {
                if (key.ToString().StartsWith("_script_"))
                {
                    if (htmlHelper.ViewContext.HttpContext.Items[key] is Func<object, HelperResult> template)
                    {
                        htmlHelper.ViewContext.Writer.Write(template(null));
                    }
                }
            }
            return null;
        }
    }
}
