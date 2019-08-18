using System.Collections.Generic;

namespace LandingPager.Models.ViewModels
{
    public class LandingFeatureViewModel
    {
        public LandingFeature Feature { get; set; }
        public IEnumerable<LandingFeature> Features { get; set; }
    }
}