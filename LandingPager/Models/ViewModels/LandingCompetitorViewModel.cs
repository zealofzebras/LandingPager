using System.Collections.Generic;

namespace LandingPager.Models.ViewModels
{
    public class LandingCompetitorViewModel
    {
        public LandingCompetitor Competitor { get; set; }
        public IEnumerable<LandingFeature> Features { get; set; }

    }
}