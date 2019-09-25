using System.Collections.Generic;

namespace LandingPager.Models
{
    public class LandingCompetitor : ILandingItem
    {
        public string Title { get; set; }
        public string Contents { get; set; }
        public List<string> Features { get; set; }
        public List<string> Cons { get; set; }
        public IEnumerable<string> Keywords { get; set; }
    }
}