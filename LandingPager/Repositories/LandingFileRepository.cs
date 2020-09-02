using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace LandingPager.Repositories
{
    public class LandingFileRepository : LandingMemoryRepository
    {
        /// <summary>
        /// Simple repository based on local files.
        /// </summary>
        public LandingFileRepository(IOptionsMonitor<LandingFileRepositoryOptions> optionsMonitor, IKeywordExtractor keywordExtractor) : base(keywordExtractor)
        {


            var features = JsonSerializer.Deserialize<List<Models.LandingFeature>>(File.ReadAllText(optionsMonitor.CurrentValue.FeaturesFile));
            foreach (var feature in features)
                Add(feature);


            var competitors = JsonSerializer.Deserialize<List<Models.LandingCompetitor>>(File.ReadAllText(optionsMonitor.CurrentValue.CompetitorsFile));
            foreach (var competitor in competitors)
                Add(competitor);

        }
    }
}
