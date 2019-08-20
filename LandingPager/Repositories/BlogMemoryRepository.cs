using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using LandingPager.Models;

namespace LandingPager.Repositories
{
    public class BlogMemoryRepository : IBlogRepository, IEnumerable<BlogPost>
    {
        private readonly Dictionary<string, BlogPost> blogPosts;

        public BlogMemoryRepository()
        {
            blogPosts = new Dictionary<string, BlogPost>();
        }

        public void Add(BlogPost blogPost)
        {
            blogPosts.Add(blogPost.Title.ToLowerInvariant(), blogPost);
        }

        public IEnumerable<BlogPost> GetAllBlogPosts()
        {
            return blogPosts.Values;
        }

        public BlogPost GetBlogPost(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("message", nameof(title));

            return blogPosts[title.ToLowerInvariant()];
        }

        public IEnumerator<BlogPost> GetEnumerator() => blogPosts.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => blogPosts.Values.GetEnumerator();
    }
}
