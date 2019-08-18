using System;
using System.Collections.Generic;
using System.Text;

namespace LandingPager.Repositories
{
    public interface IBlogRepository
    {
        Models.BlogPost GetBlogPost(string title);
    }
}
