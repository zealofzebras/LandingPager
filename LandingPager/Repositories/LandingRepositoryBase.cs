using System;
using System.Collections.Generic;
using System.Text;

namespace LandingPager.Repositories
{
    public abstract class LandingRepositoryBase : ILandingRepository
    {
        public abstract Models.LandingFeature GetFeature(string title);
        public abstract Models.LandingCompetitor GetCompetitor(string title);

        public abstract IEnumerable<Models.LandingFeature> GetAllFeatures();

        public virtual Models.ViewModels.LandingCompetitorViewModel GetCompetitorViewModel(string title)
        {
            return new Models.ViewModels.LandingCompetitorViewModel()
            {
                Features = GetAllFeatures(),
                Competitor = GetCompetitor(title)
            };
        }

        public virtual Models.ViewModels.LandingFeatureViewModel GetFeatureViewModel(string title)
        {
            return new Models.ViewModels.LandingFeatureViewModel()
            {
                Features = GetAllFeatures(),
                Feature = GetFeature(title)
            };
        }
    }
}
