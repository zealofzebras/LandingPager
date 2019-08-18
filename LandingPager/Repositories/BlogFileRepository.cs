using System;
using System.Collections.Generic;
using System.Text;

namespace LandingPager.Repositories
{
    public class BlogFileRepository : BlogMemoryRepository
    {
        public BlogFileRepository(string blogFolder) : base()
        {
            foreach (var file in System.IO.Directory.GetFiles(blogFolder, "*.html"))
            {
                this.Add(FileToBlogPost(file));
            }
        }

        internal Models.BlogPost FileToBlogPost(string filename)
        {
            var html = System.IO.File.ReadAllText(filename);
            return new Models.BlogPost()
            {
                Title = GetTitle(html),
                Contents = html
            };
        }


        internal string GetTitle(string html)
        {
            var m = System.Text.RegularExpressions.Regex.Match(html, @"<h(\d)>\s*(.+?)\s*<\/h\1>");
            if (m.Success)
            {
                return m.Groups[2].Value;
            }
            else
            {
                return "";
            }
        }


    }
}
