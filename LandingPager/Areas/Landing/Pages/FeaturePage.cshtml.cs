using System.Collections.Generic;
using LandingPager.Models;
using LandingPager.Models.ViewModels;
using LandingPager.Repositories;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LandingPager.Landing.Pages
{
    public class FeatureModel : PageModel
    {
        private readonly ILandingRepository repository;

        public LandingFeatureViewModel FeatureView { get; private set; }
        public IEnumerable<LandingFeature> Features { get; private set; }

        public FeatureModel(ILandingRepository landingRepository)
        {
            repository = landingRepository;
        }

        public void OnGet()
        {
            if (RouteData.Values["title"] != null)
            {
                FeatureView = repository.GetFeatureViewModel(RouteData.Values["title"].ToString());
            } else
            {
                Features = repository.GetAllFeatures();
            }
        }
    }

}