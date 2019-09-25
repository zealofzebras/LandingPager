using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using LandingPager.Models;

namespace LandingPager.Repositories
{
    public class BlogMemoryRepository : IBlogRepository, IEnumerable<BlogPost>
    {
        internal readonly Dictionary<string, BlogPost> blogPosts;
        private readonly IKeywordExtractor keywordExtractor;
        
        public BlogMemoryRepository(IKeywordExtractor keywordExtractor)
        {
            blogPosts = new Dictionary<string, BlogPost>();
            this.keywordExtractor = keywordExtractor;
        }

        public virtual void Add(BlogPost blogPost)
        {
            blogPost.Keywords = keywordExtractor.ExtractKeywords(blogPost);
            blogPosts.Add(blogPost.Title.ToLowerInvariant(), blogPost);
        }

        public virtual IEnumerable<BlogPost> GetAllBlogPosts()
        {
            return blogPosts.Values;
        }

        public virtual BlogPost GetBlogPost(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("message", nameof(title));

            return blogPosts[title.ToLowerInvariant()];
        }

        public virtual IEnumerator<BlogPost> GetEnumerator() => blogPosts.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => blogPosts.Values.GetEnumerator();
    }
}
