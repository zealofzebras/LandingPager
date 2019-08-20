using System;
using System.Collections.Generic;
using System.Text;

namespace LandingPager.Repositories
{
    public interface ILandingRepository
    {
        IEnumerable<Models.LandingFeature> GetAllFeatures();
        IEnumerable<Models.LandingCompetitor> GetAllCompetitors();

        Models.LandingCompetitor GetCompetitor(string title);
        Models.ViewModels.LandingCompetitorViewModel GetCompetitorViewModel(string title);

        Models.LandingFeature GetFeature(string title);
        Models.ViewModels.LandingFeatureViewModel GetFeatureViewModel(string title);
    }
}
