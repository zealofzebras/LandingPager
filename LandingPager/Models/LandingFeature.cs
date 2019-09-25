using System.Collections.Generic;

namespace LandingPager.Models
{
    public class LandingFeature : ILandingItem
    {
        public string Title { get; set; }
        public string Contents { get; set; }
        public string Image { get; set; }
        public IEnumerable<string> Keywords { get; set; }
    }

}