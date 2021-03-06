﻿using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Text;

namespace LandingPager.Extensions
{
    public static class LinkGeneratorExtensions
    {
        public static string GetBlogPostRouteUrl(this LinkGenerator linkGenerator, Models.BlogPost blog)
        {
            if (string.IsNullOrWhiteSpace(blog?.Title))
                throw new ArgumentNullException(nameof(blog));
            
            return linkGenerator.GetPathByPage("/Index", null, values: new
            {
                area = "blog",
                title = blog.Title.ToLowerInvariant(),
            });
        }

        public static string GetFeatureRouteUrl(this LinkGenerator linkGenerator, Models.LandingFeature feature)
        {
            if (string.IsNullOrWhiteSpace(feature?.Title))
                throw new ArgumentNullException(nameof(feature));

            return linkGenerator.GetPathByPage("/FeaturePage", null, values: new
            {
                area = "landing",
                title = feature.Title.ToLowerInvariant(),
            });
        }

        public static string GetCompetitorRouteUrl(this LinkGenerator linkGenerator, Models.LandingCompetitor competitor)
        {
            if (string.IsNullOrWhiteSpace(competitor?.Title))
                throw new ArgumentNullException(nameof(competitor));

            return linkGenerator.GetPathByPage("/CompetitorPage", null, values: new
            {
                area = "landing",
                title = competitor.Title.ToLowerInvariant(),
            });
        }
    }
}
