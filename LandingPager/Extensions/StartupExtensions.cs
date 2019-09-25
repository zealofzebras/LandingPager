using LandingPager.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace LandingPager.Extensions
{
    public static class StartupExtensions
    {
        public static void AddLandingPager(this IServiceCollection services)
        {
            services.AddSingleton<KeywordExtractor>();
        }

        public static void UseLandingPager(this IApplicationBuilder builder)
        {

            // Only init the blog posts AFTER all services are initialized
            var serviceProvider = builder.ApplicationServices;
            var blogRepository = serviceProvider.GetService(typeof(IBlogRepository));
            if (blogRepository is BlogFileRepository blogFileRepository)
                blogFileRepository.Init();

        }
    }
}
