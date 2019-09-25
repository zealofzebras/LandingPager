using System.Collections.Generic;

namespace LandingPager
{
    public class KeywordExtractorOptions
    {
        public IEnumerable<string> StopWords { get; internal set; }
        public int Limit { get; internal set; }
    }
}