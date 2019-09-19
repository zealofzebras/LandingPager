using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace LandingPager.Repositories
{
    public class BlogFileRepository : BlogMemoryRepository
    {

        private readonly string blogFolder;

        public BlogFileRepository(IOptionsMonitor<BlogFileRepositoryOptions> optionsMonitor) : base()
        {
            blogFolder = optionsMonitor.CurrentValue.Folder;
        }

        internal void Init()
        {
            foreach (var file in System.IO.Directory.GetFiles(blogFolder, "*.html"))
            {
                this.Add(FileToBlogPost(file));
            }
        }

        internal Models.BlogPost FileToBlogPost(string filename)
        {
            var html = System.IO.File.ReadAllText(filename);
            var fileinfo = new System.IO.FileInfo(filename);            
            return new Models.BlogPost()
            {
                Title = GetTitle(html),
                Contents = html,
                Tags = new List<string>(),
                Published = fileinfo.CreationTimeUtc
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
