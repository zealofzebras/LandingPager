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
        /// <param name="featuresFile">Json file with the current site features</param>
        /// <param name="competitorsFile">Json file with list of competitors</param>
        public LandingFileRepository(string featuresFile, string competitorsFile) : base()
        {
            using (var file = File.OpenText(featuresFile))
            {
                var serializer = new JsonSerializer();
                var features = (List<Models.LandingFeature>)serializer.Deserialize(file, typeof(List<Models.LandingFeature>));
                foreach (var feature in features)
                    Add(feature);
            }

            using (var file = File.OpenText(competitorsFile))
            {
                var serializer = new JsonSerializer();
                var competitors = (List<Models.LandingCompetitor>)serializer.Deserialize(file, typeof(List<Models.LandingCompetitor>));
                foreach (var competitor in competitors)
                    Add(competitor);
            }
        }
    }
}
