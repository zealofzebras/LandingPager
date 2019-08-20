using System;
using System.Collections.Generic;
using System.Text;
using LandingPager.Models;

namespace LandingPager.Repositories
{
    public abstract class LandingRepositoryBase : ILandingRepository
    {
        public abstract LandingFeature GetFeature(string title);
        public abstract LandingCompetitor GetCompetitor(string title);

        public abstract IEnumerable<LandingFeature> GetAllFeatures();
        public abstract IEnumerable<LandingCompetitor> GetAllCompetitors();

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
