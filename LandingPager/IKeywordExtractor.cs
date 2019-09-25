namespace LandingPager
{
    public interface IKeywordExtractor
    {
        System.Collections.Generic.IEnumerable<string> ExtractKeywords(Models.ILandingItem item);
        System.Collections.Generic.IEnumerable<string> ExtractKeywords(string contents);
    }
}