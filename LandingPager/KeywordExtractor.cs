using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace LandingPager
{
    public class KeywordExtractor : IKeywordExtractor
    {

        private readonly IOptionsMonitor<KeywordExtractorOptions> options;

        public KeywordExtractor(IOptionsMonitor<KeywordExtractorOptions>  options)
        {
            this.options = options;
        }

        public IEnumerable<string> ExtractKeywords(Models.ILandingItem item)
        {
            if (item.Keywords != null)
                return item.Keywords;

            return ExtractKeywords(item.Contents);
        }

        public IEnumerable<string> ExtractKeywords(string contents)
        {
            var stopWords = new HashSet<string>(options.CurrentValue.StopWords, StringComparer.OrdinalIgnoreCase);

            var matches = Regex.Matches(contents, @"\w([:']?\w)*", RegexOptions.IgnoreCase);

            var keywords = new Dictionary<string, int>();

            foreach (Match match in matches)
            {
                if (!stopWords.Contains(match.Value))
                {
                    if (keywords.ContainsKey(match.Value))
                        keywords[match.Value]++;
                    else
                        keywords.Add(match.Value, 1);
                }
            }

            return keywords.OrderByDescending(i => i.Value).Take(options.CurrentValue.Limit).Select(i => i.Key);
        }
    }
}
