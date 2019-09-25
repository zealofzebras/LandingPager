namespace LandingPager.Models
{
    public interface ILandingItem
    {
        string Title { get; set; }
        string Contents { get; set; }
        System.Collections.Generic.IEnumerable<string> Keywords { get; set; }
    }
}