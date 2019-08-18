using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LandingPager.Blog.Pages
{
    public class IndexModel : PageModel
    {
        public string RouteDataTextTemplateValue { get; private set; }

        public void OnGet()
        {
            if (RouteData.Values["title"] != null)

            {

                RouteDataTextTemplateValue = $"Route data for 'title' was provided: {RouteData.Values["title"]}";

            }

        }
    }
}