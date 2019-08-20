using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LandingPager.Models;
using LandingPager.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LandingPager.Blog.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IBlogRepository repository;

        public BlogPost BlogPost { get; private set; }

        public IEnumerable<BlogPost> BlogPosts { get; private set; }

        public IndexModel(LandingPager.Repositories.IBlogRepository blogRepository)
        {
            repository = blogRepository;
        }

        public void OnGet()
        {
            if (RouteData.Values["title"] != null)
            {
                BlogPost = repository.GetBlogPost(RouteData.Values["title"].ToString());
            }
            else
            {
                BlogPosts = repository.GetAllBlogPosts();
            }

        }
    }
}