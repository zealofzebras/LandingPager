using System.Collections.Generic;

namespace LandingPager
{
    public class KeywordExtractorOptions
    {
        public IEnumerable<string> StopWords { get; set; }
        public int Limit { get; set; }
    }
}