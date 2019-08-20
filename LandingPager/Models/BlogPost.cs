using System;
using System.Collections.Generic;
using System.Text;

namespace LandingPager.Models
{
    public class BlogPost
    {
        public string Title { get; set; }
        public string Contents { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public DateTime? Published { get; set; }
    }
}
