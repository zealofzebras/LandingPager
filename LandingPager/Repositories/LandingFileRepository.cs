using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LandingPager.Repositories
{
    public class LandingFileRepository : LandingMemoryRepository
    {
        /// <summary>
        /// Simple repository based on local files.
        /// </summary>
        public LandingFileRepository(IOptionsMonitor<LandingFileRepositoryOptions> optionsMonitor, IKeywordExtractor keywordExtractor) : base(keywordExtractor)
        {
            using (var file = File.OpenText(optionsMonitor.CurrentValue.FeaturesFile))
            {
                var serializer = new JsonSerializer();
                var features = (List<Models.LandingFeature>)serializer.Deserialize(file, typeof(List<Models.LandingFeature>));
                foreach (var feature in features)
                    Add(feature);
            }

            using (var file = File.OpenText(optionsMonitor.CurrentValue.CompetitorsFile))
            {
                var serializer = new JsonSerializer();
                var competitors = (List<Models.LandingCompetitor>)serializer.Deserialize(file, typeof(List<Models.LandingCompetitor>));
                foreach (var competitor in competitors)
                    Add(competitor);
            }
        }
    }
}
