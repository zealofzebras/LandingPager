using System;
using System.Collections.Generic;
using System.Text;
using LandingPager.Models;

namespace LandingPager.Repositories
{
    public interface IBlogRepository
    {
        Models.BlogPost GetBlogPost(string title);
        IEnumerable<BlogPost> GetAllBlogPosts();
    }
}
