﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LandingPager.Models;
using Newtonsoft.Json;

namespace LandingPager.Repositories
{
    public class LandingMemoryRepository : LandingRepositoryBase, IEnumerable
    {
        private readonly Dictionary<string, LandingFeature> features;
        private readonly Dictionary<string, LandingCompetitor> competitors;

        public LandingMemoryRepository()
        {
            features = new Dictionary<string, LandingFeature>();
            competitors = new Dictionary<string, LandingCompetitor>();
        }

        public void SaveToFeaturesJsonFile(string filename) => System.IO.File.WriteAllText(filename, JsonConvert.SerializeObject(features.Values, Formatting.Indented));

        public void SaveToCompetitorsJsonFile(string filename) => System.IO.File.WriteAllText(filename, JsonConvert.SerializeObject(competitors.Values, Formatting.Indented));

        public void Add(LandingFeature feature) => features.Add(feature.Name, feature);

        public void Add(LandingCompetitor competitor) => competitors.Add(competitor.Name, competitor);

        public override IEnumerable<LandingFeature> GetAllFeatures() => features.Values;

        public override LandingCompetitor GetCompetitor(string title) => competitors[title];

        public override LandingFeature GetFeature(string title) => features[title];

        IEnumerator IEnumerable.GetEnumerator() => competitors.Cast<object>().Union(features.Cast<object>()).GetEnumerator();
    }
}