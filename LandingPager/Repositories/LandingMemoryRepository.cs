﻿using LandingPager.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace LandingPager.Repositories
{
    public class LandingMemoryRepository : LandingRepositoryBase, IEnumerable
    {
        private readonly Dictionary<string, LandingFeature> features;
        private readonly Dictionary<string, LandingCompetitor> competitors;
        private readonly IKeywordExtractor keywordExtractor;
        private readonly JsonSerializerOptions indendedJsonOptions = new JsonSerializerOptions() { WriteIndented = true };

        public LandingMemoryRepository(IKeywordExtractor keywordExtractor)
        {
            features = new Dictionary<string, LandingFeature>();
            competitors = new Dictionary<string, LandingCompetitor>();
            this.keywordExtractor = keywordExtractor;
        }

        public void SaveToFeaturesJsonFile(string filename) => System.IO.File.WriteAllText(filename, JsonSerializer.Serialize(features.Values, indendedJsonOptions));

        public void SaveToCompetitorsJsonFile(string filename) => System.IO.File.WriteAllText(filename, JsonSerializer.Serialize(competitors.Values, indendedJsonOptions));

        public void Add(LandingFeature feature)
        {
            feature.Keywords = keywordExtractor.ExtractKeywords(feature);
            features.Add(feature.Title.ToLowerInvariant(), feature);
        }

        public void Add(LandingCompetitor competitor)
        {
            competitor.Keywords = keywordExtractor.ExtractKeywords(competitor);
            competitors.Add(competitor.Title.ToLowerInvariant(), competitor);
        }

        public override IEnumerable<LandingFeature> GetAllFeatures() => features.Values;

        public override LandingCompetitor GetCompetitor(string title) => competitors[title.ToLowerInvariant()];

        public override LandingFeature GetFeature(string title) => features[title.ToLowerInvariant()];

        IEnumerator IEnumerable.GetEnumerator() => competitors.Cast<object>().Union(features.Cast<object>()).GetEnumerator();

        public override IEnumerable<LandingCompetitor> GetAllCompetitors() => competitors.Values;

    }
}
