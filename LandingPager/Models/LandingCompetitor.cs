using System.Collections.Generic;

namespace LandingPager.Models
{
    public class LandingCompetitor
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Features { get; set; }
        public List<string> Cons { get; set; }
    }
}