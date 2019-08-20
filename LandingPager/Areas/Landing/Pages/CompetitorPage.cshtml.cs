using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LandingPager.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LandingPager.Landing.Pages
{
    public class CompetitorModel : PageModel
    {
        private readonly ILandingRepository repository;

        public Models.ViewModels.LandingCompetitorViewModel CompetitorView { get; private set; }

        public IEnumerable<Models.LandingCompetitor> Competitors { get; private set; }

        public CompetitorModel(ILandingRepository landingRepository)
        {
            repository = landingRepository;
        }

        public void OnGet()
        {
            if (RouteData.Values["title"] != null)
            {
                CompetitorView = repository.GetCompetitorViewModel(RouteData.Values["title"].ToString());
            } else
            {
                Competitors = repository.GetAllCompetitors();
            }

        }
    }
}